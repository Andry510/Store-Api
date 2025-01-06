using Microsoft.AspNetCore.Mvc;
using store.Dtos.Authentication;
using store.Interfaces;
using store.Messages;
using store.Mappers;
using store.Models;


namespace store.Controllers;

[ApiController]
[Route("[controller]")]

public class AuthenticationController(
    IAuthenticationService authenticationService
) : ControllerBase, IAuthenticationController
{
    [HttpPost("sign-up")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BaseResponseMessage))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(BaseResponseMessage))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseMessage))]
    public async Task<ActionResult<BaseResponseMessage>> Register([FromBody] RegisterProfileDto body)
    {
        if (!ModelState.IsValid)
            throw new BadHttpRequestException("Error");

        var transformBody = AuthenticationMapper.FromRegisterDtoToAuthentication(body);
        
        var response = await authenticationService.Create(transformBody);

        if (!response)
            throw new InvalidOperationException();

        var result = new BaseResponseMessage
        {
            Message = MessagesClass.SuccessCreate()
        };

        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseMessage))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(BaseResponseMessage))]
    public async Task<ActionResult<BaseResponseLogin>> Login([FromBody] LoginDto body)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var token = await authenticationService.Login(body);

        if (token == null)
            throw new UnauthorizedAccessException();

        var result = new BaseResponseLogin
        {
            Message = MessagesClass.SuccessLogin(),
            Token = token,
        };

        return StatusCode(StatusCodes.Status200OK, result);
    }

}
