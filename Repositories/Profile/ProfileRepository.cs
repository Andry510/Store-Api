using Microsoft.EntityFrameworkCore;
using store.Interfaces;
using store.Contexts;
using store.Models;

namespace store.Repositories;

public class ProfileRepository(DataBaseContext DbContext) : IProfileRepository
{
    
    public async Task Save(Profile data)
    {
        DbContext.Profiles.Add(data); 
        await DbContext.SaveChangesAsync();       
    }
    
    public async Task<Profile?> FindOneById(Guid id)
    {
        var data = await DbContext.Profiles.FirstOrDefaultAsync<Profile>(p => p.Id == id);
        return data;
    }    
}
