namespace HelpDebugGov.Api.Common;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
class ReqPermissionsAttribute : Attribute
{
    private readonly string[] _permissions;
    public ReqPermissionsAttribute(params string[] permissions)
    {
        // get Logged in user from HttpContext

        _permissions = permissions;
    }
}