using HisabPro.Constants;

namespace HisabPro.Web.DTO
{
    public class LoginRes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int UserRole { get; set; } = (int)UserRoleEnum.User;
    }
}
