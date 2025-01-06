namespace store.Interfaces;

public interface IJwtService
{
    string GenerateToken(string profileId);    
    
}
