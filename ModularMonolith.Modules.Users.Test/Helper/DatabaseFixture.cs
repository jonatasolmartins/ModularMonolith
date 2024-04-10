using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.Users.Core.DAL;

namespace ModularMonolith.Modules.Users.Test.Helper;

public class DatabaseFixture : IDisposable
{
    public UsersDbContext UserDbContext;
    
    public DatabaseFixture()
    {
        var optionsDb = new DbContextOptionsBuilder<UsersDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        
        UserDbContext = new UsersDbContext(optionsDb.Options);
    }

    public void Dispose()
    {
        UserDbContext?.Dispose();
    }
}