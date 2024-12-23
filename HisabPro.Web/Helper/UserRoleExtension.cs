using HisabPro.Constants;
using System.Security.Claims;

namespace HisabPro.Web.Helper
{
    public static class UserRoleExtension
    {
        public static UserRoleEnum? GetUserRole(this ClaimsPrincipal user)
        {
            var roleClaim = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (roleClaim != null)
            {
                foreach (UserRoleEnum role in Enum.GetValues(typeof(UserRoleEnum)))
                {
                    var enumText = role.GetEnumText(); // Fetch custom attribute text
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
