using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Common.Behaviors;
using HelpDebugGov.Application.Common.Handlers;
using MediatR;
using System.Reflection;

namespace HelpDebugGov.Api.Configurations;

public static class MediatRSetup
{
    public static IServiceCollection AddMediatRSetup(this IServiceCollection services)
    {
        services.AddMediatR(typeof(HelpDebugGov.Application.IAssemblyMarker).GetTypeInfo().Assembly);

        services.AddScoped<INotificationHandler<ValidationError>, ValidationErrorHandler>();


        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        return services;
    }
}