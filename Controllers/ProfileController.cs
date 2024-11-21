using Microsoft.AspNetCore.Mvc;
using store.Interfaces;

namespace store.Controllers;

[ApiController]
[Route("api[controller]")]
public class ProfileController : ControllerBase, IProfileController
{
    private readonly IProfileService profileService;

    public ProfileController(IProfileService service)
    {
        profileService = service;
    }
}
