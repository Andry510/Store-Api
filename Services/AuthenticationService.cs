using store.Enums;
using store.Interfaces;
using store.Models;

namespace store.Services;

public class AuthenticationService(
    IAuthenticationRepository authenticationRepository,
    IProfileRepository profileRepository,
    IHashingService hashing
) : IAuthenticationService
{
    private async Task<bool> IsEmailExist(string email)
    {
        var response = await authenticationRepository.FindOneByEmail(email);
        return response == null;
    }

    public async Task<Authentication?> Create(Authentication authentication)
    {
        if (!await IsEmailExist(authentication.Email))
            return null;

        authentication.Password = hashing.HashPassword(authentication.Password);

        await profileRepository.Save(authentication.Profile);
        await authenticationRepository.Save(authentication);

        return authentication;
    }
}
