using ModularMonolith.Shared.Exceptions;

namespace ModularMonolith.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class WalletNotFoundException(Guid walletId)
    : SharedException($"Wallet with ID: '{walletId}' was not found.")
{
    public Guid OwnerId { get; }
    public string Currency { get; }
    public Guid WalletId { get; } = walletId;
}