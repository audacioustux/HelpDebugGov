using HelpDebugGov.Application.Auth;
using HelpDebugGov.Infrastructure.Context;

using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Api.Configurations;

public static class PersistanceSetup
{
    public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}