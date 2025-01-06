using Microsoft.EntityFrameworkCore;
using store.Interfaces;
using store.Contexts;
using store.Models;

namespace store.Repositories;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly DataBaseContext _db;

    public AuthenticationRepository(DataBaseContext db) => _db = db;

    public async Task Save(Authentication data)
    {
        _db.Authentications.Add(data);
        await _db.SaveChangesAsync();
    }

    public async Task<Authentication?> FindOneById(Guid id)
    {
        var data = await _db.Authentications.FirstOrDefaultAsync<Authentication>(a => a.Id == id);
        return data;
    }

    public async Task<Authentication?> FindOneByEmail(string email)
    {
        try
        {
            var data = await _db.Authentications.FirstOrDefaultAsync(a => a.Email == email);

            return data;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
