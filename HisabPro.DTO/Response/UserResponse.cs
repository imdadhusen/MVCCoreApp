using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; } = (int)UserRoleEnum.User;
        public string UserRoleName { get; set; }
        public int Gender { get; set; } = (int)UserGenederEnum.Male;
        public string GenderName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = DataFormat.Grid.Date)]
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
