using System.ComponentModel.DataAnnotations;

namespace ModularMonolith.Modules.Users.Shared.DTO;

public class UserDetailsDto : UserDto
{
    [Required]
    public string Address { get; set; }
        
    [Required]
    public string Identity { get; set; }
}