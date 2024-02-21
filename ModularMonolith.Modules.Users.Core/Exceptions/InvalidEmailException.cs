using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Users.Core.Exceptions;

internal sealed class InvalidEmailException(string email) : SharedException($"Email: '{email}' is invalid.")
{
    public string Email { get; } = email;
}