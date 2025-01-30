using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveExpenseReq
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.TitleMax, MinimumLength = FieldsSizeCommonConst.TitleMin, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationTitle))]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationDate))]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldDate))]
        public DateTime ExpenseOn { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationAmount))]
        public double Amount { get; set; }
        [StringLength(FieldsSizeCommonConst.NoteMax, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationNote))]
        public string? Note { get; set; }
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldIsActive))]
        public bool IsActive { get; set; } = true;

        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldAccount))]
        public int? AccountId { get; set; }
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldCategory))]
        public int? CategoryId { get; set; }
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldSubCategory))]
        public int? SubCategoryId { get; set; }
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldBulkImport))]
        public bool IsBulkImported { get; set; } = false;
    }
}
