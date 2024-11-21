using Microsoft.AspNetCore.Mvc;
using store.Dtos.Authentication;
using store.Interfaces;
using store.Models;

namespace store.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase, IAuthenticationController
{
    private readonly IAuthenticationService authenticationService;

    public AuthenticationController(IAuthenticationService service)
    {
        authenticationService = service;
    }

    [HttpPost]
    public ActionResult<BaseResponse<Authentication>> Create([FromBody] CreateProfileDto body)
    {
        throw new NotImplementedException();
    }
}
