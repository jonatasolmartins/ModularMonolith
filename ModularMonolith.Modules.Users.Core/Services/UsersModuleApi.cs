using ModularMonolith.Modules.Users.Shared;
using ModularMonolith.Modules.Users.Shared.DTO;

namespace ModularMonolith.Modules.Users.Core.Services;

internal sealed class UsersModuleApi(IUsersService usersService) : IUsersModuleApi
{
    public Task<UserDetailsDto> GetUserAsync(Guid userId) => usersService.GetAsync(userId);
        
    public Task<UserDetailsDto> GetUserAsync(string email) => usersService.GetAsync(email);
}