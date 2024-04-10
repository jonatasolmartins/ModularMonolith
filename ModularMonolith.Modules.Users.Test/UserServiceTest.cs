using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.Extensions.Logging;
using ModularMonolith.Modules.Users.Core.Entities;
using ModularMonolith.Modules.Users.Core.Services;
using ModularMonolith.Modules.Users.Shared.DTO;
using ModularMonolith.Modules.Users.Shared.Events;
using ModularMonolith.Modules.Users.Test.Helper;
using ModularMonolith.Shared.Exceptions;
using Moq;
using Shouldly;
using Wolverine;

namespace ModularMonolith.Modules.Users.Test;

public class UserServiceTest : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _databaseFixture;
    public UserServiceTest(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }
    private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    [Fact]
    
    public async Task Try_to_get_user_by_id()
    {
        #region Arrange
        var userId = Guid.NewGuid();
        
        await _databaseFixture.UserDbContext.AddAsync(new User(userId, "", "", "", "","", DateTime.Now));
        await _databaseFixture.UserDbContext.SaveChangesAsync();
        
        _fixture.Register(() => _databaseFixture);

        var iLogger = new Logger<UsersService>(new LoggerFactory());
        var messageBus = _fixture.Freeze<Mock<IMessageBus>>();
        
        messageBus.Setup(x => x.PublishAsync(It.IsAny<UserCreated>(), null))
            .Returns(ValueTask.CompletedTask);
        
        var userService = new UsersService(_databaseFixture.UserDbContext, messageBus.Object, iLogger);
        
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

    
    [Theory]
    /* Another option is to use ->
     [MemberData(nameof(TestHelper.UserDtos), MemberType = typeof(TestHelper))] */
    [ClassData(typeof(TestHelper))]
    public async Task Try_Add_User_Async_And_Throw<TSharedException>(TSharedException _, UserDetailsDto userDetailsDto, string email) where TSharedException : SharedException
    {
      
        #region Arrange
        
        await _databaseFixture.UserDbContext.AddAsync(
            new User(userDetailsDto.UserId, email, userDetailsDto.FullName, userDetailsDto.Address, 
                userDetailsDto.Nationality,userDetailsDto.Identity, userDetailsDto.CreatedAt));
        
        await _databaseFixture.UserDbContext.SaveChangesAsync();
        
        var iLogger = new Logger<UsersService>(new LoggerFactory());
        var messageBus = _fixture.Freeze<Mock<IMessageBus>>();
        
        var usersService = new UsersService(_databaseFixture.UserDbContext, messageBus.Object, iLogger);
        Exception ex = null;
        #endregion

        #region Act
        
        try
        {
            await usersService.AddAsync(userDetailsDto);
        }
        catch (Exception e)
        {
            ex = e;
        }
        #endregion

        #region Assert

        ex.ShouldBeOfType<TSharedException>();
        //Should.Throw<TSharedException>(async () => await usersService.AddAsync(userDetailsDto));

        #endregion
    }
}