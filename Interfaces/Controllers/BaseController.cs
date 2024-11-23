using Microsoft.AspNetCore.Mvc;
using store.Models;

namespace store.Interfaces;

public interface IBaseController<T, TCreateDto>
{
    Task<ActionResult<BaseResponse<T>>> Register([FromBody] TCreateDto body);
}
