using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Users.Api.EndPoints;
using ModularMonolith.Modules.Users.Core;

namespace ModularMonolith.Modules.Users.Api;

public static class Extension
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddCoreLayer();
        return services;
    }
    
    public static IApplicationBuilder UseUsersModule(this IApplicationBuilder app, Func<string, IEndpointRouteBuilder> appGroup)
    {
        app.UseEndpoints(endpoints  =>
        {
            var usersEndPoint = endpoints.MapGroup("/users");
            usersEndPoint.MapPost("/create", UserEndpoint.CreateUser);
            usersEndPoint.MapGet("/verify", UserEndpoint.VerifyUser);
            usersEndPoint.MapGet("/{id:guid}", UserEndpoint.GetUser);
            usersEndPoint.MapGet("/{email}", UserEndpoint.Get);
            usersEndPoint.MapGet("/", UserEndpoint.GetAllUser);
        });
        
        return app;
    }
}