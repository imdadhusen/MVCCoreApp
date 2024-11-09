using HisabPro.Entities.IEntities;
using System.Security.Claims;

namespace HisabPro.Web.Entities
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetCurrentUserId()
        {
            // Assuming user ID is stored in claims
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : throw new InvalidOperationException("User is not authenticated");
        }

        public string GetCurrentUserName()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null || !user.Identity.IsAuthenticated)
            {
                return "Anonymous";
            }

            // Typically, the username is stored in the ClaimTypes.Name or a custom claim
            var username = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            // If username is not found, handle it accordingly
            return username ?? "Unknown User";
        }
    }
}
