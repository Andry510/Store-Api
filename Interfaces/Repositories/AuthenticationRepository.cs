using store.Models;

namespace store.Interfaces;

public interface IAuthenticationRepository : IBaseRepository<Authentication>
{
    public Task<Authentication?> FindOneByEmail(string email);
}
