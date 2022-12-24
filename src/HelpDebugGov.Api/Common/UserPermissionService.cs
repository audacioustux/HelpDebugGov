using System.Security.Claims;

using HelpDebugGov.Application.Common;

using Microsoft.EntityFrameworkCore;

namespace HelpDebugGov.Api.Common;

public interface IUserPermissionService
{
    ValueTask<ClaimsIdentity?> GetUserPermissionsIdentity(string sub, CancellationToken cancellationToken);
}

public class UserPermissionService : IUserPermissionService
{
    private readonly IContext _dbContext;

    public UserPermissionService(IContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<ClaimsIdentity?> GetUserPermissionsIdentity(
        string sub, CancellationToken cancellationToken)
    {
        // var userPermissions = await
        //     (from up in _dbContext.UserPermissions
        //      join perm in _dbContext.Permissions on up.PermissionId equals perm.Id
        //      join user in _dbContext.Users on up.UserId equals user.Id
        //      where user.ExternalId == sub
        //      select new Claim(AppClaimTypes.Permissions, perm.Name)).ToListAsync(cancellationToken);

        var userPermissions = await _dbContext.Users
        .Where(u => u.Id == Guid.Parse(sub))
        .SelectMany(u => u.Permissions)
        .Select(p => new Claim("permissions", p.Id.ToString())).ToListAsync(cancellationToken);


        return CreatePermissionsIdentity(userPermissions);
    }

    private static ClaimsIdentity? CreatePermissionsIdentity(IReadOnlyCollection<Claim> claimPermissions)
    {
        if (!claimPermissions.Any())
            return null;

        var permissionsIdentity = new ClaimsIdentity(nameof(PermissionsMiddleware), "name", "role");
        permissionsIdentity.AddClaims(claimPermissions);

        return permissionsIdentity;
    }
}