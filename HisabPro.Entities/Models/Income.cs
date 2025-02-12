using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.Entities.Models
{
    public class Income : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        
        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [StringLength(FieldsSizeCommonConst.TitleMax, MinimumLength = FieldsSizeCommonConst.TitleMin, ErrorMessage = ResourceKey.ValidationTitle)]
        public string Title { get; set; }
        
        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(ResourceKey), ErrorMessageResourceName = nameof(ResourceKey.ValidationDate))]
        public DateTime IncomeOn { get; set; }
       
        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [Range(0, int.MaxValue, ErrorMessage = ResourceKey.ValidationAmount)]
        public double Amount { get; set; }
        
        [StringLength(FieldsSizeCommonConst.NoteMax, ErrorMessage = ResourceKey.ValidationNote)]
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
