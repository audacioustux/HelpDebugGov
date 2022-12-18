using HelpDebugGov.Application.Auth;
using HelpDebugGov.Infrastructure.Context;

using Microsoft.EntityFrameworkCore;

using ISession = HelpDebugGov.Domain.Auth.Interfaces.ISession;

namespace HelpDebugGov.Api.Configurations;

public static class PersistanceSetup
{
    public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ISession, Session>();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}