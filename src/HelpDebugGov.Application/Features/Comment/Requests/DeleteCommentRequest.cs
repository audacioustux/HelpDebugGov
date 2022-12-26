namespace HelpDebugGov.Application.Features.Comments.Requests;

using MediatR;
using OneOf;
using Responses;

public record DeleteCommentRequest(Guid Id) : IRequest<OneOf<bool, CommentNotFound>>;