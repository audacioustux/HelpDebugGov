using System.Text;

using HelpDebugGov.Application.Common;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace HelpDebugGov.Api.Configurations;

public static class AuthSetup
{
    public static IServiceCollection AddAuthSetup(this IServiceCollection services, IConfiguration configuration)
    {
        var tokenConfig = configuration.GetRequiredSection("TokenConfiguration");
        services.Configure<TokenConfiguration>(tokenConfig);

        var appSettings = tokenConfig.Get<TokenConfiguration>();
        var key = Encoding.ASCII.GetBytes(appSettings!.Secret);
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = appSettings.Issuer,
                    ValidAudience = appSettings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        services.AddAuthorization(options =>
        {
            options.InvokeHandlersAfterFailure = false;
        });

        return services;
    }
}