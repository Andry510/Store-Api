using Microsoft.AspNetCore.Mvc;
using store.Models;

namespace store.Interfaces;

public interface IBaseController<T, TCreateDto>
{
    ActionResult<BaseResponse<T>> Create([FromBody] TCreateDto body);
}
