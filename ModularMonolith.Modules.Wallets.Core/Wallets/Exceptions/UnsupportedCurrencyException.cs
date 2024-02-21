using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class UnsupportedCurrencyException(string currency)
    : SharedException($"Currency: '{currency}' is unsupported.")
{
    public string Currency { get; } = currency;
}