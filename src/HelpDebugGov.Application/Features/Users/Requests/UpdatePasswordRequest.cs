namespace HelpDebugGov.Application.Features.Users.Requests;

using System.Text.Json.Serialization;
using MediatR;
using Responses;

public record UpdatePasswordRequest : IRequest<GetUserResponse>
{
    [JsonIgnore]
    public Guid Id { get; init; }

    public string Password { get; init; } = null!;
}