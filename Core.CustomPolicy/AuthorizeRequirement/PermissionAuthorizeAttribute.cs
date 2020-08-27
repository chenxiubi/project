﻿using Microsoft.AspNetCore.Authorization;

namespace Core.CustomPolicy
{
    /// <summary>
    /// 特性来在控制器应用自定义的策略的特性
    /// </summary>
    public class PermissionAuthorizeAttribute : AuthorizeAttribute
    {
        const string POLICY_PREFIX = "Permission";

        public PermissionAuthorizeAttribute(string permissionName) => PermissionName = permissionName;
        public string PermissionName
        {
            get
            {
                return PermissionName;
            }
            set
            {
                Policy = $"{POLICY_PREFIX}{value.ToString()}";
            }
        }
    }
}
