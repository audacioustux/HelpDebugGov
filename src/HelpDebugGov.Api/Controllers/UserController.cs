using HelpDebugGov.Application.Common.Responses;
using HelpDebugGov.Application.Features.Auth.Authenticate;
using HelpDebugGov.Application.Features.Users.Requests;
using HelpDebugGov.Application.Features.Users.Responses;
using HelpDebugGov.Domain.Auth;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ISession = HelpDebugGov.Domain.Auth.ISession;

namespace HelpDebugGov.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly ISession _session;
    private readonly IMediator _mediator;

    public UserController(ISession session, IMediator mediator)
    {
        _session = session;
        _mediator = mediator;
    }

    [ProducesResponseType(typeof(PaginatedList<GetUserResponse>), StatusCodes.Status200OK)]
    [Authorize(Roles = Roles.Admin)]
    [HttpGet]
    public async Task<ActionResult<PaginatedList<GetUserResponse>>> GetUsers([FromQuery] GetUsersRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var result = await _mediator.Send(new GetUserByIdRequest(id));
        return result.Match<IActionResult>(
            found => Ok(found),
            notFound => NotFound());
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GetUserResponse>> CreateUser(CreateUserRequest request)
    {
        var newAccount = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetUserById), new { id = newAccount.Id }, newAccount);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var result = await _mediator.Send(new DeleteUserRequest(id));
        return result.Match<IActionResult>(
            deleted => NoContent(),
            notFound => NotFound());
    }
}