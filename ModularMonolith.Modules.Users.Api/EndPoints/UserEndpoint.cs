using Microsoft.AspNetCore.Http;
using ModularMonolith.Modules.Users.Core.Services;
using ModularMonolith.Modules.Users.Shared.DTO;

namespace ModularMonolith.Modules.Users.Api.EndPoints;

public static class UserEndpoint
{
    public static async Task<IResult> CreateUser(IUsersService usersService, UserDetailsDto user)
    {
        user.UserId = Guid.NewGuid();
        await usersService.AddAsync(user);
        return TypedResults.Created(nameof(CreateUser), new { userId = user.UserId });
    }
    
    public static async Task<IResult> VerifyUser(IUsersService usersService, Guid userId)
    {
        await usersService.VerifyAsync(userId);
        return TypedResults.NoContent();
    }
    
    public static async Task<IResult> GetUser(IUsersService usersService, Guid id)
    {
        var user = await usersService.GetAsync(id);
        return user is {Email: ""} ?  TypedResults.NotFound() : TypedResults.Ok(user);
    }
    
    public static async Task<IResult> Get(IUsersService usersService, string email)
    {
        var user = await usersService.GetAsync(email);
        return user is {Email: ""} ?  TypedResults.NotFound() : TypedResults.Ok(user);
    }
    
    public static async Task<IResult> GetAllUser(IUsersService usersService)
        => TypedResults.Ok(await usersService.BrowseAsync());
    
}