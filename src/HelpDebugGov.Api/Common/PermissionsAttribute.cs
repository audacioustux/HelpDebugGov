
using System;

using Microsoft.AspNetCore.Authorization;

namespace HelpDebugGov.Api.Common
{
    public enum PermissionOperator
    {
        And = 1,
        Or = 2
    }

    public class PermissionsAttribute : AuthorizeAttribute
    {
        internal const string PolicyPrefix = "PERMISSION_";
        private const string Separator = "_";

        public PermissionsAttribute(PermissionOperator permissionOperator, params string[] permissions)
        {
            Policy = $"{PolicyPrefix}{(int)permissionOperator}{Separator}{string.Join(Separator, permissions)}";
        }

        public PermissionsAttribute(string permission)
        {
            Policy = $"{PolicyPrefix}{(int)PermissionOperator.And}{Separator}{permission}";
        }

        public static PermissionOperator GetOperatorFromPolicy(string policyName)
        {
            var @operator = int.Parse(policyName.AsSpan(PolicyPrefix.Length, 1));
            return (PermissionOperator)@operator;
        }

        public static string[] GetPermissionsFromPolicy(string policyName)
        {
            return policyName.Substring(PolicyPrefix.Length + 2)
                .Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
