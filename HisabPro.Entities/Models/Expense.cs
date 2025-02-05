using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.Entities.Models
{
    public class Expense : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [StringLength(FieldsSizeCommonConst.TitleMax, MinimumLength = FieldsSizeCommonConst.TitleMin, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationTitle))]
        public string Title { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationDate))]
        public DateTime ExpenseOn { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationAmount))]
        public double Amount { get; set; }
        [StringLength(FieldsSizeCommonConst.NoteMax, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationNote))]
        public string? Note { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public Category SubCategory { get; set; }
        public int SubCategoryId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public int AccountId { get; set; }

        public bool IsBulkImported { get; set; } = false;
    }
}
