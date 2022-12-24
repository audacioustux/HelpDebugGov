using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace HelpDebugGov.Api.Common;

public class PermissionsMiddleware : IMiddleware
{
    private readonly ILogger<PermissionsMiddleware> _logger;
    private readonly IUserPermissionService _permissionService;

    public PermissionsMiddleware(
        ILogger<PermissionsMiddleware> logger,
        IUserPermissionService permissionService
        )
    {
        _logger = logger;
        _permissionService = permissionService;
    }

    public async Task InvokeAsync(
        HttpContext context, RequestDelegate next)
    {
        if (context.User.Identity == null || !context.User.Identity.IsAuthenticated)
        {
            await next(context);
            return;
        }

        var cancellationToken = context.RequestAborted;

        var userSub = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userSub))
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            var result = JsonSerializer.Serialize(new { error = $"{ClaimTypes.NameIdentifier} claim is missing" });
            await context.Response.WriteAsync(result);
            return;
        }

        var permissionsIdentity = await _permissionService.GetUserPermissionsIdentity(userSub, cancellationToken);
        if (permissionsIdentity is null)
        {
            _logger.LogWarning("User {sub} does not have permissions", userSub);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            var result = JsonSerializer.Serialize(new { error = $"Access Forbidden" });
            await context.Response.WriteAsync(result);
            return;
        }

        // User has permissions, so we add the extra identity containing the "permissions" claims
        context.User.AddIdentity(permissionsIdentity);
        await next(context);
    }
}