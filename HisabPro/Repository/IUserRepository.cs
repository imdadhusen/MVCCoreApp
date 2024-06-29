using HisabPro.DTO;
using HisabPro.Entities;

namespace HisabPro.Repository
{
    public interface IUserRepository
    {
        public Task<LoginRes?> GetUserByEmail(string email);
        Task<User?> Register(string name, string email, string password);
        Task<LoginRes?> Authenticate(string email, string password);
    }   
}
