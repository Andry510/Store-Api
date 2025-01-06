using store.Dtos.Authentication;
using store.Models;

namespace store.Interfaces;

public interface IAuthenticationService
{
    Task<bool> Create(Authentication authentication);
    Task<string?> Login(LoginDto authentication);
}
