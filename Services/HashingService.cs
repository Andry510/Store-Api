using Microsoft.AspNetCore.Identity;
using store.Interfaces;
using store.Models;

namespace store.Services;

public class HashingService: IHashingService
{    
    private readonly PasswordHasher<Authentication> passwordHasher = new();

    public string HashPassword(string password)
    {
        return passwordHasher.HashPassword(null!, password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var result = passwordHasher.VerifyHashedPassword(null!, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}
