using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Users.Core.Exceptions;

internal sealed class InvalidFullNameException(string fullName)
    : SharedException($"Full name: '{fullName}' is invalid.")
{
    public string FullName { get; } = fullName;
}