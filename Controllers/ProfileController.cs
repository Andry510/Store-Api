using Microsoft.AspNetCore.Mvc;
using store.Interfaces;

namespace store.Controllers;

[ApiController]
[Route("api[controller]")]
public class ProfileController(IProfileService service) : ControllerBase, IProfileController
{
}
