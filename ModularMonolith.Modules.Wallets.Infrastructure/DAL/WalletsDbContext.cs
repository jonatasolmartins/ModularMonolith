using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.Wallets.Core.Owners.Aggregates;
using ModularMonolith.Modules.Wallets.Core.Wallets.Aggregates;
using ModularMonolith.Modules.Wallets.Core.Wallets.Entities;

namespace ModularMonolith.Modules.Wallets.Infrastructure.DAL;

internal class WalletsDbContext(DbContextOptions<WalletsDbContext> options) : DbContext(options)
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Transfer> Transfers { get; set; }
    public DbSet<Wallet> Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("wallets");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}