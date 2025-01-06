using Microsoft.AspNetCore.Mvc;
using store.Models;

namespace store.Interfaces;

public interface IProfileController
{
    ActionResult<Task<BaseResponseMessage>> GetProfile();
}
