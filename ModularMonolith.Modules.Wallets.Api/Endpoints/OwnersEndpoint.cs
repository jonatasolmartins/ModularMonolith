using Microsoft.AspNetCore.Http;
using ModularMonolith.Modules.Wallets.Application.Owners.Commands;

namespace ModularMonolith.Modules.Wallets.Api.Endpoints;

public static class OwnersEndpoint
{
    public static async Task<IResult> Post(AddOwner command)
    {
        //await _dispatcher.SendAsync(command);
        return await Task.FromResult(TypedResults.NoContent());
    }
}