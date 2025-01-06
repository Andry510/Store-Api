using Microsoft.AspNetCore.Identity;
using store.Interfaces;
using store.Models;

namespace store.Services;

public class HashingService: IHashingService
{    
    private readonly PasswordHasher<Authentication> passwordHasher = new();

    public string GenerateHash(string password)
    {
        return passwordHasher.HashPassword(null!, password);
    }

    public bool VerifyHash(string plainText, string hashedText)
    {
        var result = passwordHasher.VerifyHashedPassword(null!, hashedText, plainText);
        return result == PasswordVerificationResult.Success;
    }
}
