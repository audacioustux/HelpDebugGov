using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using ISession = HelpDebugGov.Domain.Auth.ISession;
namespace HelpDebugGov.Api.Common;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class HasPermissionAttribute : Attribute, IAsyncActionFilter
{
    private readonly string _permission;

    public HasPermissionAttribute(string permission)
    {
        _permission = permission;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var session = (ISession?)context.HttpContext.RequestServices.GetService(typeof(ISession));
        if (session is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var hasPermissions = await session.HasPermission(_permission);
        if (!hasPermissions)
        {
            context.Result = new ForbidResult();
            return;
        }

        await next();
    }
}