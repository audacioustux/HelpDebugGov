using HelpDebugGov.Application.Common.Responses;
using HelpDebugGov.Application.Features.Auth.Authenticate;
using HelpDebugGov.Application.Features.Users.Requests;
using HelpDebugGov.Application.Features.Users.Responses;
using HelpDebugGov.Domain.Auth;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ISession = HelpDebugGov.Domain.Auth.Interfaces.ISession;

namespace HelpDebugGov.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AuthController : ControllerBase
{
    private readonly ISession _session;
    private readonly IMediator _mediator;

    public AuthController(ISession session, IMediator mediator)
    {
        _session = session;
        _mediator = mediator;
    }

    [HttpPost]
    [Route("authenticate")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Jwt), StatusCodes.Status200OK)]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
    {
        var jwt = await _mediator.Send(request);
        if (jwt == null)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }
        return Ok(jwt);
    }

    [HttpPatch("password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request)
    {
        await _mediator.Send(request with { Id = _session.UserId });
        return NoContent();
    }

    [AllowAnonymous]
    [HttpPost("register")]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var newAccount = await _mediator.Send(request);

        return Ok(newAccount);
        // return CreatedAtAction(nameof(UserController.GetUserById), new { id = newAccount?.Id }, newAccount);
    }
}