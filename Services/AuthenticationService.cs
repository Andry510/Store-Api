using Microsoft.AspNetCore.Http.HttpResults;
using store.Interfaces;
using store.Messages;
using store.Models;

namespace store.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository authenticationRepository;

    public AuthenticationService(IAuthenticationRepository repository)
    {
        authenticationRepository = repository;
    }

    public async Task<Authentication?> Create(Authentication authentication)
    {
        var isEmailExist = await authenticationRepository.FindOneByEmail(authentication.Email);

        if (isEmailExist != null)
            return null;

        throw new NotImplementedException();
    }
}
