using HisabPro.DTO.Model;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using System.Linq.Expressions;

namespace HisabPro.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUser(Expression<Func<User, bool>> where);
        Task<ResponseDTO<LoginRes?>> Authenticate(string email, string password);
    }   
}
