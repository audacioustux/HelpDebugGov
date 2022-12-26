using HelpDebugGov.Api.Common;
using HelpDebugGov.Application.Common.Responses;
using HelpDebugGov.Application.Features.Auth.Authenticate;
using HelpDebugGov.Application.Features.Organizations.Requests;
using HelpDebugGov.Application.Features.Organizations.Responses;
using HelpDebugGov.Domain.Auth;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ISession = HelpDebugGov.Domain.Auth.ISession;

namespace HelpDebugGov.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrganizationController : ControllerBase
{
    private readonly ISession _session;
    private readonly IMediator _mediator;

    public OrganizationController(ISession session, IMediator mediator)
    {
        _session = session;
        _mediator = mediator;
    }

    [HasPermission("Organization.Read")]
    [ProducesResponseType(typeof(PaginatedList<GetOrganizationResponse>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<ActionResult<PaginatedList<GetOrganizationResponse>>> GetOrganizations([FromQuery] GetOrganizationsRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HasPermission("Organization.Read.ById")]
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetOrganizationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrganizationById(Guid id)
    {
        var result = await _mediator.Send(new GetOrganizationByIdRequest(id));
        return result.Match<IActionResult>(
            found => Ok(found),
            notFound => NotFound());
    }

    [HasPermission("Organization.Create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GetOrganizationResponse>> CreateOrganization(CreateOrganizationRequest request)
    {
        var newAccount = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetOrganizationById), new { id = newAccount.Id }, newAccount);
    }

    [HasPermission("Organization.Delete")]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteOrganization(Guid id)
    {
        var result = await _mediator.Send(new DeleteOrganizationRequest(id));
        return result.Match<IActionResult>(
            deleted => NoContent(),
            notFound => NotFound());
    }
}