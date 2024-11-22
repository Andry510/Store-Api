using store.Dtos.Authentication;
using store.Models;

namespace store.Interfaces;

public interface IAuthenticationController : IBaseController<Authentication, CreateProfileDto> { }