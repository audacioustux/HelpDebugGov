using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<ServiceResponse<Guid>>> Register(UserRegisterDTO userRegisterDTO)
    {
        return await _unitOfWork.Users.Register(userRegisterDTO);
    }
}
