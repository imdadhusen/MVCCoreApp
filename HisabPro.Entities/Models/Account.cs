using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.Entities.Models
{
    public class Account : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(FieldsSizeConst.Account.NameMax, MinimumLength = FieldsSizeConst.Account.NameMin, ErrorMessage = FieldsSizeConst.Account.NameMessage)]
        public string Name { get; set; }
        [StringLength(FieldsSizeConst.Account.FullNameMax, ErrorMessage = FieldsSizeConst.Account.FullNameMessage)]
        public string FullName { get; set; }
        [StringLength(FieldsSizeCommonConst.Mobile.Len, MinimumLength = FieldsSizeCommonConst.Mobile.Len, ErrorMessage = FieldsSizeCommonConst.Mobile.Message)]
        [RegularExpression(FieldsSizeCommonConst.Mobile.RegEx, ErrorMessage = FieldsSizeCommonConst.Mobile.RegExMessage)]
        public string? Mobile { get; set; }

        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expense> Expenses { get; set; }

        public Account()
        {
            //Collection is initialized properly to avoid null reference issues.
            Incomes = new List<Income>();
            Expenses = new List<Expense>();
        }
    }
}
