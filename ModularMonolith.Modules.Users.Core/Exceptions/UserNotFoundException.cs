using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Users.Core.Exceptions;

internal sealed class UserNotFoundException(Guid userId) : SharedException($"User with ID: '{userId}' was not found.")
{
    public Guid UserId { get; } = userId;
}