﻿using HisabPro.Constants;
using System.Security.Claims;

namespace HisabPro.Web.Helper
{
    public static class UserRoleExtension
    {
        public static EnumUserRole? GetUserRole(this ClaimsPrincipal user, ISharedViewLocalizer _localizer)
        {
            var roleClaim = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (roleClaim != null)
            {
                foreach (EnumUserRole role in Enum.GetValues(typeof(EnumUserRole)))
                {
                    var enumText = role.GetLocalizedEnumText(_localizer); // Fetch custom attribute text
                    if (enumText == roleClaim)
                    {
                        return role;
                    }
                }
            }
            return null;
        }
    }
}
