namespace HelpDebugGov.Application.Features.Organizations.Requests;

using HelpDebugGov.Application.Common.Requests;
using HelpDebugGov.Application.Common.Responses;
using MediatR;

public record GetOrganizationsRequest : PaginatedRequest, IRequest<PaginatedList<Responses.GetOrganizationResponse>>
{
}