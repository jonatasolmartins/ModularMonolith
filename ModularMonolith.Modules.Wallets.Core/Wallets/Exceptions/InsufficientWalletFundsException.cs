using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class InsufficientWalletFundsException(Guid walletId)
    : SharedException($"Insufficient funds for wallet with ID: '{walletId}'.")
{
    public Guid WalletId { get; } = walletId;
}