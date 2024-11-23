using Microsoft.EntityFrameworkCore;
using store.Interfaces;
using store.Contexts;
using store.Models;

namespace store.Repositories;

public class AuthenticationRepository(DataBaseContext DbContext) : IAuthenticationRepository
{
    public async Task Save(Authentication data)
    {
        DbContext.Authentications.Add(data);
        await DbContext.SaveChangesAsync();
    }

    public async Task<Authentication?> FindOneById(Guid id)
    {
        var data = await DbContext.Authentications.FirstOrDefaultAsync<Authentication>(a => a.Id == id);
        return data;
    }

    public async Task<Authentication?> FindOneByEmail(string email)
    {
        var data = await DbContext.Authentications.FirstOrDefaultAsync<Authentication>(a => a.Email == email);
        return data;
    }
}
