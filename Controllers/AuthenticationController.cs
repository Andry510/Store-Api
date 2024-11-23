using Microsoft.AspNetCore.Mvc;
using store.Dtos.Authentication;
using store.Interfaces;
using store.Messages;
using store.Mappers;
using store.Models;

namespace store.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(IAuthenticationService service) : ControllerBase, IAuthenticationController
{
    [HttpPost("sign-in")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponse<Authentication>>> Register([FromBody] CreateProfileDto body)
    {
        if (!ModelState.IsValid)
            return BadRequest(MessagesClass.ErrorCreate());

        // var transformBody = AuthenticationMapper.ToAuthentication(body);
        // var data = await service.Create(transformBody);

        // if (data == null)
        //     return Conflict(new { Message = MessagesClass.AlreadyExists() });

        return CreatedAtAction(
            nameof(Register),
            new BaseResponse<Authentication>
            {
                Message = MessagesClass.SuccessCreate(),
                // Data = data,
            }
        );
    }
}
