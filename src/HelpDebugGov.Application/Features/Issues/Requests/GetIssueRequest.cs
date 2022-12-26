namespace HelpDebugGov.Application.Features.Issues.Requests;

using HelpDebugGov.Application.Common.Requests;
using HelpDebugGov.Application.Common.Responses;
using MediatR;

public record GetIssuesRequest : PaginatedRequest, IRequest<PaginatedList<Responses.GetIssueResponse>>
{
}