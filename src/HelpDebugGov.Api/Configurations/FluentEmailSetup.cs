using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.MappingProfiles;
using HelpDebugGov.Infrastructure.Context;

using MassTransit;
using MassTransit.NewIdProviders;

namespace HelpDebugGov.Api.Configurations;

public static class FluentEmailSetup
{
    public static IServiceCollection AddFluentEmailSetup(this IServiceCollection services)
    {
        var FromEmail = Environment.GetEnvironmentVariable("EMAIL_FROM");
        var FromName = Environment.GetEnvironmentVariable("EMAIL_FROM_NAME");
        var MAILGUN_DOMAIN = Environment.GetEnvironmentVariable("MAILGUN_DOMAIN");
        var MAILGUN_API_KEY = Environment.GetEnvironmentVariable("MAILGUN_API_KEY");

        services
            .AddFluentEmail(FromEmail, FromName)
            .AddMailGunSender(MAILGUN_DOMAIN, MAILGUN_API_KEY);

        return services;
    }
}