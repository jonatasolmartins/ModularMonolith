using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Wallets.Core.Owners.Exceptions;

internal sealed class InvalidNationalityException(string nationality)
    : SharedException($"Nationality: '{nationality}' is invalid.")
{
    public string Nationality { get; } = nationality;
}