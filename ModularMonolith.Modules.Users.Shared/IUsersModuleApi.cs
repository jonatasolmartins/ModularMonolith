using ModularMonolith.Modules.Users.Shared.DTO;

namespace ModularMonolith.Modules.Users.Shared;

public interface IUsersModuleApi
{
    Task<UserDetailsDto> GetUserAsync(Guid userId);
    Task<UserDetailsDto> GetUserAsync(string email);
}