using System.Threading.Tasks;

using HelpDebugGov.Application.Common;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HelpDebugGov.Api.Configurations;

public static class MigrationsSetup
{
    public static async Task Migrate(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<IAssemblyMarker>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<IContext>();
        if (dbContext.Database.IsNpgsql())
        {
            logger.LogInformation("Running migrations...");
            await dbContext.Database.MigrateAsync();
            logger.LogInformation("Migrations applied succesfully");

        }
    }
}