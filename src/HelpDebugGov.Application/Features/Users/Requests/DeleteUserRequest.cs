namespace HelpDebugGov.Application.Features.Users.Requests;

using MediatR;
using OneOf;
using Responses;

public record DeleteUserRequest(Guid Id) : IRequest<OneOf<bool, UserNotFound>>;