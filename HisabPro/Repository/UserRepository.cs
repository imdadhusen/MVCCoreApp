using AutoMapper;
using HisabPro.DTO;
using HisabPro.Entities;
using HisabPro.Tools.PasswordService;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HisabPro.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LoginRes?> GetUser(Expression<Func<User, bool>> predicate)
        {
            User? data = null;
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
            string passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

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
