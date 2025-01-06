using store.Dtos.Authentication;
using store.Models;

namespace store.Mappers;

public class AuthenticationMapper
{
    public static Authentication FromRegisterDtoToAuthentication(RegisterProfileDto dto)
    {
        if (dto == null)
            throw new BadHttpRequestException(nameof(dto));

        return new Authentication
        {
            Email = dto.Email,
            Password = dto.Password,
            Profile = new Profile
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Rol = dto.Rol,
            }
        };
    }
}
