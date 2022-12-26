using HelpDebugGov.Api.Common;
using HelpDebugGov.Application.Common.Responses;
using HelpDebugGov.Application.Features.Auth.Authenticate;
using HelpDebugGov.Application.Features.Issues.Requests;
using HelpDebugGov.Application.Features.Issues.Responses;
using HelpDebugGov.Domain.Auth;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ISession = HelpDebugGov.Domain.Auth.ISession;

namespace HelpDebugGov.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class IssueController : ControllerBase
{
    private readonly ISession _session;
    private readonly IMediator _mediator;

    public IssueController(ISession session, IMediator mediator)
    {
        _session = session;
        _mediator = mediator;
    }

    [HasPermission("Issue.Read")]
    [ProducesResponseType(typeof(PaginatedList<GetIssueResponse>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<ActionResult<PaginatedList<GetIssueResponse>>> GetIssues([FromQuery] GetIssuesRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HasPermission("Issue.Read.ById")]
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetIssueResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetIssueById(Guid id)
    {
        var result = await _mediator.Send(new GetIssueByIdRequest(id));
        return result.Match<IActionResult>(
            found => Ok(found),
            notFound => NotFound());
    }

    [HasPermission("Issue.Create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GetIssueResponse>> CreateIssue(CreateIssueRequest request)
    {
        var newAccount = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetIssueById), new { id = newAccount.Id }, newAccount);
    }

    [HasPermission("Issue.Delete")]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteIssue(Guid id)
    {
        var result = await _mediator.Send(new DeleteIssueRequest(id));
        return result.Match<IActionResult>(
            deleted => NoContent(),
            notFound => NotFound());
    }
}