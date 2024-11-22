using Microsoft.EntityFrameworkCore;
using store.Contexts;
using store.Interfaces;
using store.Models;

namespace store.Repositories;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly DataBaseContext db;

    public AuthenticationRepository(DataBaseContext DBContext)
    {
        db = DBContext;
    }
    public Task<Authentication> Save()
    {
        throw new NotImplementedException();
    }

    public Task<Authentication> FindOneById()
    {
        throw new NotImplementedException();
    }

    public async Task<Authentication?> FindOneByEmail(string email)
    {
       var data = await db.Authentications.FirstOrDefaultAsync(a => a.Email == email);
       return data;
    }
}
