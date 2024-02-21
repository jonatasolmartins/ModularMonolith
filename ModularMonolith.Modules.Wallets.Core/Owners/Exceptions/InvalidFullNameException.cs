using ModularMonolith.Shared.Exceptions;
namespace ModularMonolith.Modules.Wallets.Core.Owners.Exceptions;

internal sealed class InvalidFullNameException(string fullName)
    : SharedException($"Full name: '{fullName}' is invalid.")
{
    public string FullName { get; } = fullName;
}