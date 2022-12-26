namespace HelpDebugGov.Application.Features.Comments.Requests;

using MediatR;
using OneOf;
using Responses;

public record GetCommentByIdRequest(Guid Id) : IRequest<OneOf<GetCommentResponse, CommentNotFound>>;