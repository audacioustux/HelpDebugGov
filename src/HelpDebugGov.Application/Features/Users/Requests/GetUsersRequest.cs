namespace HelpDebugGov.Application.Features.Users.Requests;

using HelpDebugGov.Application.Common.Requests;
using HelpDebugGov.Application.Common.Responses;
using MediatR;

public record GetUsersRequest : PaginatedRequest, IRequest<PaginatedList<Responses.GetUserResponse>>
{
    public string? Email { get; init; }
}