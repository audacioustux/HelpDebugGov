using System;

namespace HelpDebugGov.Application.Common.Responses;

public record Jwt
{
    public required string Token { get; init; }
    public DateTime ExpDate { get; init; }
}