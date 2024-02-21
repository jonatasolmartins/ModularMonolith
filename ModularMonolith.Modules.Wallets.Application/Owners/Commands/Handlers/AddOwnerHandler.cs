using Microsoft.Extensions.Logging;
using ModularMonolith.Modules.Users.Shared;
using ModularMonolith.Modules.Wallets.Application.Owners.Exceptions;
using ModularMonolith.Modules.Wallets.Core.Owners.Aggregates;
using ModularMonolith.Modules.Wallets.Core.Owners.Repositories;

namespace ModularMonolith.Modules.Wallets.Application.Owners.Commands.Handlers;

internal sealed class AddOwnerHandler(
    IOwnerRepository ownerRepository,
    IUsersModuleApi usersModuleApi,
    ILogger<AddOwnerHandler> logger)
    //: ICommandHandler<AddOwner>
{
    public async Task HandleAsync(AddOwner command, CancellationToken cancellationToken = default)
    {
        var user = await usersModuleApi.GetUserAsync(command.Email);
        if (user is null)
        {
            throw new UserNotFoundException(command.Email);
        }

        if (await ownerRepository.GetAsync(user.UserId) is { } owner1)
        {
            throw new OwnerAlreadyExistsException(command.Email);
        }

        var now = DateTime.UtcNow;
        var owner = new Owner(user.UserId, user.FullName, user.Nationality, now);
        await ownerRepository.AddAsync(owner);
        logger.LogInformation("Created an owner for the user with ID: '{0}'.", user.UserId);
    }
}