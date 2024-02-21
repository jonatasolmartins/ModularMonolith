using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.Users.Core.Entities;

namespace ModularMonolith.Modules.Users.Core.DAL;

internal sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}