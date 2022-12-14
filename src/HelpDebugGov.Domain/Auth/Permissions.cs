using HelpDebugGov.Domain.Entities;

namespace HelpDebugGov.Domain.Auth;

public static class Permissions
{
    public static Permission[] GeneratePermissionsForModule(string module)
    {
        return new[] {
            new Permission { Action = $"{module}", Description = $"All permissions in `{module}` scope" },
            new Permission { Action = $"{module}.Read", Description = $"Read `{module}` data" },
            new Permission { Action = $"{module}.Read.ById", Description = $"Read `{module}` data by Id" },
            new Permission { Action = $"{module}.Delete", Description = $"Delete `{module}` data" },
            new Permission { Action = $"{module}.Delete.Own", Description = $"Delete own `{module}` data" },
            new Permission { Action = $"{module}.Create", Description = $"Create `{module}` data" },
            new Permission { Action = $"{module}.Update", Description = $"Update `{module}` data" },
            new Permission { Action = $"{module}.Update.Own", Description = $"Update own `{module}` data" }
        };
    }
}