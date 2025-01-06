using Microsoft.EntityFrameworkCore;
using store.Interfaces;
using store.Contexts;
using store.Models;

namespace store.Repositories;

public class ProfileRepository : IProfileRepository
{
    
    private readonly DataBaseContext _db;

    public ProfileRepository(DataBaseContext db) => _db = db;
    
    public async Task Save(Profile data)
    {
        _db.Profiles.Add(data);
        await _db.SaveChangesAsync();
    }

    public async Task<Profile?> FindOneById(Guid id)
    {
        var data = await _db.Profiles.FirstOrDefaultAsync<Profile>(p => p.Id == id);
        return data;
    }
}
