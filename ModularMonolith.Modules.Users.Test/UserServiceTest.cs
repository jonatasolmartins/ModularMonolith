using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModularMonolith.Modules.Users.Core.DAL;
using ModularMonolith.Modules.Users.Core.Entities;
using ModularMonolith.Modules.Users.Core.Services;
using ModularMonolith.Modules.Users.Shared.Events;
using Moq;
using Shouldly;
using Wolverine;

namespace ModularMonolith.Modules.Users.Test;

public class UserServiceTest
{
    private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    [Fact]
    public async Task Try_to_get_user_by_id()
    {
        #region Arrange
        var userId = Guid.NewGuid();
        
        var optionsDb = new DbContextOptionsBuilder<UsersDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        
        var userDbContext = new UsersDbContext(optionsDb.Options);
        
        await userDbContext.AddAsync(new User(userId, "", "", "", "","", DateTime.Now));
        await userDbContext.SaveChangesAsync();
        
        _fixture.Register(() => userDbContext);

        var iLogger = new Logger<UsersService>(new LoggerFactory());
        var messageBus = _fixture.Freeze<Mock<IMessageBus>>();
        
        messageBus.Setup(x => x.PublishAsync(It.IsAny<UserCreated>(), null))
            .Returns(ValueTask.CompletedTask);
        
        var userService = new UsersService(userDbContext, messageBus.Object, iLogger);
        
        #endregion

        #region Act
        var user = await userService.GetAsync(userId);
        #endregion

        #region Assert
        messageBus.Verify(x => x.PublishAsync(It.IsAny<UserCreated>(), null), Times.Never);
        user.ShouldNotBeNull();
        user.UserId.ShouldBe(userId);
        #endregion
    }
}