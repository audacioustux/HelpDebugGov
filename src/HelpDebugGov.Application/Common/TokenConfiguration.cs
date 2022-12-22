namespace HelpDebugGov.Application.Common;

public class TokenConfiguration
{
    public required string Secret { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }

}