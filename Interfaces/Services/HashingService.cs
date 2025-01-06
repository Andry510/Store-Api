namespace store.Interfaces;

public interface IHashingService
{
    string GenerateHash(string password);
    bool  VerifyHash(string plainText, string hashedText);
}
