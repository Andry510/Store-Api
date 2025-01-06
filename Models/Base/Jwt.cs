namespace store.Models;

public class Jwt
{
    public string Key { get; set; } = "";
    public string Subject { get; set; } = "";
    public int ExpiresInMinutes { get; set; }
}
