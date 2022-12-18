namespace HelpDebugGov.Application.Features.Users.Requests;

using MediatR;
using OneOf;
using Responses;

public record GetUserByIdRequest(Guid Id) : IRequest<OneOf<GetUserResponse, UserNotFound>>;