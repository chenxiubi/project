using Microsoft.AspNetCore.Authorization;

namespace Core.CustomPolicy
{
    /// <summary>
    /// 权限策略
    /// </summary>
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string PermissionName { get; }

        public PermissionRequirement(string permissionName)
        {
            this.PermissionName = permissionName;
        }
    }
}
