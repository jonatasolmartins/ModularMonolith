using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Users.Core.DAL;
using ModularMonolith.Modules.Users.Core.Services;
using ModularMonolith.Shared.Database;

namespace ModularMonolith.Modules.Users.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        services.AddPostgres<UsersDbContext>();
        services.AddTransient<IUsersService, UsersService>();
            
        return services;
    }
}