using ModularMonolith.Modules.Wallets.Core.Owners.SharedKernel;
using ModularMonolith.Modules.Wallets.Core.Wallets.Aggregates;
using ModularMonolith.Modules.Wallets.Core.Wallets.ValueObjects;

namespace ModularMonolith.Modules.Wallets.Core.Wallets.Repositories;

internal interface IWalletRepository
{
    Task<Wallet> GetAsync(WalletId id);
    Task<Wallet> GetAsync(OwnerId ownerId, Currency currency);
    Task AddAsync(Wallet wallet);
    Task UpdateAsync(Wallet wallet);
}