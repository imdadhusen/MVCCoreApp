using HisabPro.DTO;
using HisabPro.Entities;
using System.Linq.Expressions;

namespace HisabPro.Repository
{
    public interface IUserRepository
    {
        public Task<LoginRes?> GetUser(Expression<Func<User, bool>> where);
        Task<User?> Register(string name, string email, string password);
        Task<LoginRes?> Authenticate(string email, string password);
    }   
}
