using AutoMapper;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using HisabPro.Tools.PasswordService;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HisabPro.Repository.Implements
{
    public class UserRepository(ApplicationDbContext context, IMapper mapper) : IUserRepository
    {
        public readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<LoginRes?> GetUser(Expression<Func<User, bool>> predicate)
        {
            User? data;
            if (predicate != null)
            {
                data = await _context.Users.FirstOrDefaultAsync(predicate);
            }
            else
            {
                data = await _context.Users.FirstOrDefaultAsync();
            }

            if (data == null)
            {
                return null;
            }
            return _mapper.Map<User, LoginRes>(data);
        }
        public async Task<User?> Register(string name, string email, string password)
        {
            PasswordHelper.CreatePasswordHash(password, out string passwordHash, out string passwordSalt);

            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<LoginRes?> Authenticate(string email, string password)
        {
            var user = await GetUser(u => u.Email == email);
            if (user == null || !PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }
    }
}
