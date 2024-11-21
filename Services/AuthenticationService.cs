using store.Interfaces;
using store.Contexts;
using store.Models;

namespace store.Services;

public class AuthenticationService: IAuthenticationService
{
    private readonly DataBaseContext repository;

    public AuthenticationService(DataBaseContext _repository)
    {
        repository = _repository;
    }
    
    public Task<Authentication> Save()
    {
        throw new NotImplementedException();
    }

    public Task<Authentication> FindOneById()
    {
        throw new NotImplementedException();
    }
}
