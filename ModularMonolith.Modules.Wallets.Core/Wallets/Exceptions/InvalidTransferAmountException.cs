using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class InvalidTransferAmountException(decimal amount)
    : SharedException($"Transfer has invalid amount: '{amount}'.")
{
    public decimal Amount { get; } = amount;
}