using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Wallets.Api.Endpoints;

namespace ModularMonolith.Modules.Wallets.Api;

public static class Extension
{
    public static IServiceCollection AddWalletsModule(this IServiceCollection services)
    {
        //services.AddCoreLayer();
        return services;
    }
    
    public static IApplicationBuilder UseWalletsModule(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints  =>
        {
            var walletsEndPoint = endpoints.MapGroup("/wallets");
            walletsEndPoint.MapGet("/get/{walletId:guid}", WalletsEndpoint.Get);
            walletsEndPoint.MapPost("/create", WalletsEndpoint.Post);
            
           var fundsEndPoint = endpoints.MapGroup("/funds");
           fundsEndPoint.MapPost("/add", FundsEndpoint.Add);
           fundsEndPoint.MapPost("/transfer", FundsEndpoint.Transfer);
           
            var ownersEndPoint = endpoints.MapGroup("/owners");
            ownersEndPoint.MapPost("/create", OwnersEndpoint.Post);
        });
        
        return app;
    }
}