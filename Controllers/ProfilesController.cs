using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store.Interfaces;
using store.Messages;
using store.Models;

namespace store.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProfilesController() : ControllerBase, IProfileController
{

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseMessage))]
    public ActionResult<Task<BaseResponseMessage>> GetProfile()
    {
        var profileIdClaim = User.FindFirst("id");

        Console.WriteLine(profileIdClaim);
        
        var result = new BaseResponseMessage
        {
            Message = MessagesClass.SuccessGet()
        };

        return Ok(result);
    }
}
