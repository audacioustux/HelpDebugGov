using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.MappingProfiles;
using HelpDebugGov.Infrastructure.Context;

using MassTransit;
using MassTransit.NewIdProviders;

using Microsoft.Extensions.DependencyInjection;

namespace HelpDebugGov.Api.Configurations;

public static class ApplicationSetup
{
    public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
    {
        services.AddScoped<IContext, ApplicationDbContext>();
        NewId.SetProcessIdProvider(new CurrentProcessIdProvider());

        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}