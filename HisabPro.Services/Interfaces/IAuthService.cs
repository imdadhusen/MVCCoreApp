using HisabPro.DTO.Response;
using System.Security.Claims;

namespace HisabPro.Services.Interfaces
{
    public interface IAuthService
    {
        List<Claim> GetClaims(LoginRes user);
        Task<string?> SignInUser(LoginRes user);
        string GenerateToken(List<Claim> claims);
        int GetCurrentUserId();
        string GetCurrentUserName();
    }
}
