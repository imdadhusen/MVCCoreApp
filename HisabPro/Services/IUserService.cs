using HisabPro.Entities;

namespace HisabPro.Services
{
    public interface IUserService
    {
        Task<User?> Register(string name, string email, string password);
        Task<User?> Authenticate(string email, string password);
    }
}
