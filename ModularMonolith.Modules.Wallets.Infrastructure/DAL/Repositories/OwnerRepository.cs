using ModularMonolith.Modules.Wallets.Core.Owners.Aggregates;
using ModularMonolith.Modules.Wallets.Core.Owners.Repositories;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.Wallets.Core.Owners.SharedKernel;

namespace ModularMonolith.Modules.Wallets.Infrastructure.DAL.Repositories;

internal class OwnerRepository : IOwnerRepository
{
    private readonly WalletsDbContext _context;
    private readonly DbSet<Owner> _owners;
    
    public OwnerRepository(WalletsDbContext context)
    {
        _context = context;
        _owners = _context.Owners;
    }
    
    public Task<Owner> GetAsync(OwnerId id)
        => _owners.SingleOrDefaultAsync(x => x.Id.Equals(id))!;
    
    public async Task AddAsync(Owner owner)
    {
        await _owners.AddAsync(owner);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Owner owner)
    {
        _owners.Update(owner);
        await _context.SaveChangesAsync();
    }
}