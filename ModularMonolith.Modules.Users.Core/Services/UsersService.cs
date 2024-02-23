using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModularMonolith.Modules.Users.Core.DAL;
using ModularMonolith.Modules.Users.Core.Entities;
using ModularMonolith.Modules.Users.Core.Exceptions;
using ModularMonolith.Modules.Users.Shared.DTO;
using ModularMonolith.Modules.Users.Shared.Events;
using Wolverine;


namespace ModularMonolith.Modules.Users.Core.Services;

internal sealed class UsersService(
    UsersDbContext dbContext,
    IMessageBus messageBus,
    ILogger<UsersService> logger) : IUsersService
{
    public async Task<UserDetailsDto> GetAsync(Guid userId)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Id == userId);
            
        return user is null ? null : MapToDetailsDto(user);
    }

    public async Task<UserDetailsDto> GetAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new InvalidEmailException(email);
        }
            
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
            
        return user is null ? null : MapToDetailsDto(user);
    }

    public async Task<IReadOnlyList<UserDto>> BrowseAsync()
    {
        var users = await dbContext.Users.ToListAsync();
            
        return users.Select(MapToDto).ToList();
    }

    public async Task AddAsync(UserDetailsDto dto)
    {
        var email = dto.Email.ToLowerInvariant();
        
        if (await dbContext.Users.AnyAsync(x => x.Email == email))
        {
            throw new UserAlreadyExistsException(email);
        }
        
        if (string.IsNullOrWhiteSpace(dto.FullName))
        {
            throw new InvalidFullNameException(dto.FullName);
        }
            
        if (string.IsNullOrWhiteSpace(dto.Address))
        {
            throw new InvalidAddressException(dto.Address);
        }
            
        var user = new User(
            dto.UserId,
            email,
            dto.FullName,
            dto.Address,
            dto.Nationality,
            dto.Identity,
            DateTime.UtcNow);
        
        await dbContext.Users.AddAsync(user);
        
        await dbContext.SaveChangesAsync();
        
        await messageBus.PublishAsync(new UserCreated(user.Id, user.Email, user.FullName, user.Nationality));
        
        logger.LogInformation("Created the user with ID: '{0}' and EMAIL: {1}.", dto.UserId, dto.Email);
    }

    public async Task VerifyAsync(Guid userId)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Id == userId);
        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        user.Verify(DateTime.UtcNow);
        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync();
        
        await messageBus.PublishAsync(new UserVerified(user.Id, user.Email, user.Nationality));
        
        logger.LogInformation("Verified the user with ID: '{0}'.", user.Id);
    }

    // TODO: Extract to the dedicated "mapper" interfaces or extension methods
        
    private static UserDto MapToDto(User user)=> Map<UserDto>(user);

    private static UserDetailsDto MapToDetailsDto(User user)
    {
        var dto = Map<UserDetailsDto>(user);
        dto.Address = user.Address;
        dto.Identity = user.Identity;

        return dto;
    }

    private static T Map<T>(User user) where T : UserDto, new()
        => new()
        {
            UserId = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            Nationality = user.Nationality,
            State = user.VerifiedAt.HasValue ? "verified" : "unverified",
            CreatedAt = user.CreatedAt
        };
}