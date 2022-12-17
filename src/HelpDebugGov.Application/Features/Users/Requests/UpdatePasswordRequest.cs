namespace HelpDebugGov.Application.Features.Users.Requests;

using MediatR;
using System.Text.Json.Serialization;
using Responses;

public record UpdatePasswordRequest : IRequest<GetUserResponse>
{
    [JsonIgnore]
    public Guid Id { get; init; }

    public string Password { get; init; } = null!;
}