using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using store.Interfaces;
using store.Models;
using System.Text;

namespace store.Services;

public class JwtService(IConfiguration configuration) : IJwtService
{

    private Jwt jwt = configuration.GetSection("Jwt").Get<Jwt>()!;

    public string GenerateToken(string profileId)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwt.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim> {            
            new Claim("id", profileId),
        };

        var secToken = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims,
            expires: DateTime.Now.AddMinutes(jwt.ExpiresInMinutes),
            signingCredentials: credentials
            );


        var token = new JwtSecurityTokenHandler().WriteToken(secToken);

        return token;
    }
}
