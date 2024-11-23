using System.Text.Json.Serialization;
using store.Enums;

namespace store.Dtos.Authentication;

public class CreateProfileDto
{
    [ValidatorBody([BodyOptions.Required, BodyOptions.IsString])]
    public string Name { get; set; } = null!;

    [ValidatorBody([BodyOptions.Required, BodyOptions.IsString])]
    public string LastName { get; set; } = null!;

    [ValidatorBody([BodyOptions.Required, BodyOptions.IsEmail])]
    public string Email { get; set; } = null!;

    [ValidatorBody([BodyOptions.Required, BodyOptions.IsPassword])]
    public string Password { get; set; } = null!;

    [ValidatorBody([BodyOptions.IsRole])]
    [JsonConverter(typeof(JsonStringEnumConverter<Role>))]
    public Role? Rol { get; set; } = Role.Customer;
}

