using store.Validators;
using store.Enums;

namespace store.Dtos.Authentication;

public class LoginDto
{
    [ValidatorBody([BodyOptions.Required, BodyOptions.IsEmail])]
    public string Email { get; set; } = null!;
    
    [ValidatorBody([BodyOptions.Required, BodyOptions.IsPassword])]
    public string Password { get; set; } = null!;
}
