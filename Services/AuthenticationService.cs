using Microsoft.AspNetCore.Http.HttpResults;
using store.Dtos.Authentication;
using store.Interfaces;
using store.Messages;
using store.Models;

namespace store.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IHashingService _hashing;
    private readonly IJwtService _jwtService;

    public AuthenticationService(
        IAuthenticationRepository authenticationRepository,
        IProfileRepository profileRepository,
        IHashingService hashing,
        IJwtService jwtService
    )
    {
        _authenticationRepository = authenticationRepository;
        _profileRepository = profileRepository;
        _jwtService = jwtService;
        _hashing = hashing;
    }

    private async Task<Authentication?> IsEmailExist(string email)
    {
        try
        {
            var response = await _authenticationRepository.FindOneByEmail(email);
            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Create(Authentication authentication)
    {
        try
        {
            var profileExist = await IsEmailExist(authentication.Email);

            if (profileExist != null)
                throw new InvalidCastException();

            authentication.Password = _hashing.GenerateHash(authentication.Password);


            await _profileRepository.Save(authentication.Profile);
            await _authenticationRepository.Save(authentication);

            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string?> Login(LoginDto authentication)
    {
        try
        {
            var profileExist = await IsEmailExist(authentication.Email);

            var isMatchPassword = profileExist != null && _hashing.VerifyHash(
                authentication.Password,
                profileExist.Password
            );

            if (profileExist == null || !isMatchPassword)
                throw new InvalidCastException(MessagesClass.ErrorLogin());

            var token = _jwtService.GenerateToken(profileExist!.ProfileId.ToString());
            return token;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
