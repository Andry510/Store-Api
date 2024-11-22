using Microsoft.EntityFrameworkCore;
using store.Models;

namespace store.Contexts;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

    public DbSet<Authentication> Authentications { get; set; } = null!;
    public DbSet<Profile> Profiles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authentication>()
        .HasOne(a => a.Profile)
        .WithOne()
        .HasForeignKey<Authentication>(a => a.ProfileId)
        .OnDelete(DeleteBehavior.Cascade);
    }

}
