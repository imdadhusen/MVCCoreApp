using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Response
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = DataFormat.Grid.Date)]
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
