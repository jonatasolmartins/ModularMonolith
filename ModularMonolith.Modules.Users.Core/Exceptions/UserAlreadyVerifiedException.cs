using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Users.Core.Exceptions;

internal sealed class UserAlreadyVerifiedException(Guid userId)
    : SharedException($"User with ID: '{userId}' is already verified.")
{
    public Guid UserId { get; } = userId;
}