using System.Linq;
using System.Security.Claims;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ISession = HelpDebugGov.Domain.Auth.ISession;

namespace HelpDebugGov.Application.Auth;

public class Session : ISession
{
    private readonly IContext _context;
    public Guid UserId { get; private init; }

    public DateTime Now => DateTime.Now;

    public Session(IHttpContextAccessor httpContextAccessor, IContext context)
    {
        _context = context;

        var user = httpContextAccessor.HttpContext?.User;

        var nameIdentifier = user?.FindFirst(ClaimTypes.NameIdentifier);

        if (nameIdentifier != null)
        {
            UserId = new Guid(nameIdentifier.Value);
        }
    }

    public async Task<bool> HasPermission(string permission)
    {
        var user = _context.Users.Where(u => u.Id == UserId);

        return await user.SelectMany(u => u.Roles)
            .SelectMany(r => r.Permissions)
            .Union(user.SelectMany(u => u.Permissions))
            .Select(p => p.Action)
            .Where(action =>
                permission == action ||
                permission.StartsWith(action) ||
                action == "_"
            )
            .AnyAsync();
    }
}