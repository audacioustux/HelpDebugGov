namespace HelpDebugGov.Application.Features.Issues.Requests;

using MediatR;
using OneOf;
using Responses;

public record DeleteIssueRequest(Guid Id) : IRequest<OneOf<bool, IssueNotFound>>;