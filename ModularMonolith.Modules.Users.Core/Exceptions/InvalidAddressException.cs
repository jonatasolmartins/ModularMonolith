using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Users.Core.Exceptions;

internal sealed class InvalidAddressException(string address) : SharedException($"Address: '{address}' is invalid.")
{
    public string Address { get; } = address;
}