using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ISession = HelpDebugGov.Domain.Auth.ISession;

namespace HelpDebugGov.Application.Auth;

public class Session : ISession
{
    public Guid UserId { get; private init; }

    public DateTime Now => DateTime.Now;

    public Session(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        var nameIdentifier = user?.FindFirst(ClaimTypes.NameIdentifier);

        if (nameIdentifier != null)
        {
            UserId = new Guid(nameIdentifier.Value);
        }
    }

}