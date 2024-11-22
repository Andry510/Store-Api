using Microsoft.AspNetCore.Mvc;
using store.Dtos.Authentication;
using store.Interfaces;
using store.Messages;
using store.Models;

namespace store.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase, IAuthenticationController
{
    private readonly IAuthenticationService authenticationService;

    public AuthenticationController(IAuthenticationService service)
    {
        authenticationService = service;
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<BaseResponse<Authentication>> Create([FromBody] CreateProfileDto body)
    {
        if (!ModelState.IsValid)
            return BadRequest(MessagesClass.ErrorCreate());
        try
        {            
              return Ok();
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
