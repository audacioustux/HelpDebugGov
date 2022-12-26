namespace HelpDebugGov.Application.Features.Comments.Requests;

using HelpDebugGov.Application.Common.Requests;
using HelpDebugGov.Application.Common.Responses;
using MediatR;

public record GetCommentsRequest : PaginatedRequest, IRequest<PaginatedList<Responses.GetCommentResponse>>
{
}