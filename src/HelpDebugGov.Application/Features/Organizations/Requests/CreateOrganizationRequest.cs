namespace HelpDebugGov.Application.Features.Organizations.Requests;

using MediatR;
using Responses;

public record CreateOrganizationRequest : IRequest<GetOrganizationResponse>
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}