using HelpDebugGov.Api.Common;
using HelpDebugGov.Application.Common.Responses;
using HelpDebugGov.Application.Features.Auth.Authenticate;
using HelpDebugGov.Application.Features.Comments.Requests;
using HelpDebugGov.Application.Features.Comments.Responses;
using HelpDebugGov.Domain.Auth;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ISession = HelpDebugGov.Domain.Auth.ISession;

namespace HelpDebugGov.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CommentController : ControllerBase
{
    private readonly ISession _session;
    private readonly IMediator _mediator;

    public CommentController(ISession session, IMediator mediator)
    {
        _session = session;
        _mediator = mediator;
    }

    [HasPermission("Comment.Read")]
    [ProducesResponseType(typeof(PaginatedList<GetCommentResponse>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<ActionResult<PaginatedList<GetCommentResponse>>> GetComments([FromQuery] GetCommentsRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HasPermission("Comment.Read.ById")]
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetCommentResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCommentById(Guid id)
    {
        var result = await _mediator.Send(new GetCommentByIdRequest(id));
        return result.Match<IActionResult>(
            found => Ok(found),
            notFound => NotFound());
    }

    [HasPermission("Comment.Create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GetCommentResponse>> CreateComment(CreateCommentRequest request)
    {
        var newAccount = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetCommentById), new { id = newAccount.Id }, newAccount);
    }

    [HasPermission("Comment.Delete")]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        var result = await _mediator.Send(new DeleteCommentRequest(id));
        return result.Match<IActionResult>(
            deleted => NoContent(),
            notFound => NotFound());
    }
}