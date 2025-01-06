using Microsoft.AspNetCore.Mvc;
using store.Dtos.Authentication;
using store.Models;

namespace store.Interfaces;

public interface IAuthenticationController { 
    Task<ActionResult<BaseResponseMessage>> Register( RegisterProfileDto body);
    Task<ActionResult<BaseResponseLogin>> Login( LoginDto body);
}