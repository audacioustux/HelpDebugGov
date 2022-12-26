namespace HelpDebugGov.Application.Features.Issues.Requests;

using MediatR;
using OneOf;
using Responses;

public record GetIssueByIdRequest(Guid Id) : IRequest<OneOf<GetIssueResponse, IssueNotFound>>;