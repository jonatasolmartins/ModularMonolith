using ModularMonolith.Modules.Users.Shared.DTO;

namespace ModularMonolith.Modules.Users.Core.Services;

public interface IUsersService
{
    Task<UserDetailsDto> GetAsync(Guid userId);
    Task<UserDetailsDto> GetAsync(string email);
    Task<IReadOnlyList<UserDto>> BrowseAsync();
    Task AddAsync(UserDetailsDto dto);
    Task VerifyAsync(Guid userId);
}