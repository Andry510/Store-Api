using System.ComponentModel.DataAnnotations;
using store.Enum;

namespace store.Dtos.Authentication;

public class CreateProfileDto
{
    [Required]
    [RegularExpression(@"^[a-zA-Z\s'-]+$")]
    public required string Name { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z\s'-]+$")]
    public required string LastName { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [MinLength(6)]
    public required string Password { get; set; }

    public Role? Rol { get; set; } = Role.Employee;
}
