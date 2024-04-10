using System.Collections;
using ModularMonolith.Modules.Users.Core.Exceptions;
using ModularMonolith.Modules.Users.Shared.DTO;

namespace ModularMonolith.Modules.Users.Test.Helper;

public class TestHelper : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new UserAlreadyExistsException(""),
            new UserDetailsDto()
            {
                UserId = Guid.NewGuid(),
                Email = "existingemail",
                FullName = "sdgf",
                Nationality = "sdfsd",
                State = "sdf",
                CreatedAt = DateTime.UtcNow,
                Address = "sdf",
                Identity = "sdf"
            },
            "existingemail"
        };
        
        yield return new object[]
        {
            new InvalidFullNameException(""),
            new UserDetailsDto()
            {
                UserId = Guid.NewGuid(),
                Email = "nsabdnf",
                FullName = "",
                Nationality = "sdfsd",
                State = "sdf",
                CreatedAt = DateTime.UtcNow,
                Address = "sdf",
                Identity = "sdf"
            },
            "anotheremail@email.com"
        };
        
        yield return new object[]
        {
            new InvalidAddressException(""),
            new UserDetailsDto()
            {
                UserId = Guid.NewGuid(),
                Email = "bsdfn@jsdf.com",
                FullName = "sdgf",
                Nationality = "sdfsd",
                State = "sdf",
                CreatedAt = DateTime.UtcNow,
                Address = "    ",
                Identity = "df"
            },
            "anotheremail@email.com"
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    public static IEnumerable<object[]> UserDtos()
    {
        yield return new object[]
        {
            new UserAlreadyExistsException(""),
            new UserDetailsDto()
            {
                UserId = Guid.NewGuid(),
                Email = "existingemail",
                FullName = "sdgf",
                Nationality = "sdfsd",
                State = "sdf",
                CreatedAt = DateTime.UtcNow,
                Address = "sdf",
                Identity = "sdf"
            },
            "existingemail"
        };
        
        yield return new object[]
        {
            new InvalidFullNameException(""),
            new UserDetailsDto()
            {
                UserId = Guid.NewGuid(),
                Email = "nsabdnf",
                FullName = "",
                Nationality = "sdfsd",
                State = "sdf",
                CreatedAt = DateTime.UtcNow,
                Address = "sdf",
                Identity = "sdf"
            },
            "anotheremail@email.com"
        };
        
        yield return new object[]
        {
            new InvalidAddressException(""),
            new UserDetailsDto()
            {
                UserId = Guid.NewGuid(),
                Email = "existingemail",
                FullName = "sdgf",
                Nationality = "sdfsd",
                State = "sdf",
                CreatedAt = DateTime.UtcNow,
                Address = "    ",
                Identity = "df"
            },
            "anotheremail@email.com"
        };
    }
}