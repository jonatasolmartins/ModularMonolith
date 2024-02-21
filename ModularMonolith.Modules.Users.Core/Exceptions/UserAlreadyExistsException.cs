using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Users.Core.Exceptions;

internal sealed class UserAlreadyExistsException(string email)
    : SharedException($"User with email: '{email}' already exists.")
{
    public string Email { get; } = email;
}