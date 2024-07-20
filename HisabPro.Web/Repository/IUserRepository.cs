using HisabPro.Web.DTO;
using HisabPro.Entities.Models;
using System.Linq.Expressions;

namespace HisabPro.Web.Repository
{
    public interface IUserRepository
    {
        public Task<LoginRes?> GetUser(Expression<Func<User, bool>> where);
        Task<User?> Register(string name, string email, string password);
        Task<LoginRes?> Authenticate(string email, string password);
    }   
}
