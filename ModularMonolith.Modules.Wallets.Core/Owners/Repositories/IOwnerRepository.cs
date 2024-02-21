using System.Runtime.CompilerServices;
using ModularMonolith.Modules.Wallets.Core.Owners.Aggregates;
using ModularMonolith.Modules.Wallets.Core.Owners.SharedKernel;

[assembly: InternalsVisibleTo("ModularMonolith.Modules.Wallets.Infrastructure")]
[assembly: InternalsVisibleTo("ModularMonolith.Modules.Wallets.Application")]
namespace ModularMonolith.Modules.Wallets.Core.Owners.Repositories;

internal interface IOwnerRepository
{
    Task<Owner> GetAsync(OwnerId id);
    Task AddAsync(Owner owner);
    Task UpdateAsync(Owner owner);
}