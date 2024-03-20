using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ModularMonolith.Shared.Database;

public static class Extensions
{
    internal static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<DbContextAppInitializer>();
        return services;
    }

    public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
    { 
        var postgresConfig = services.BuildServiceProvider().GetRequiredService<IOptions<PostgresConfig>>();
        services.AddDbContext<T>(x => x.UseNpgsql(postgresConfig.Value.ConnectionString));
        services.AddHostedService<DbContextAppInitializer>();
        return services;
    }
}