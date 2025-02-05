using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveIncomeReq
    {
        public int? Id { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [StringLength(FieldsSizeCommonConst.TitleMax, MinimumLength = FieldsSizeCommonConst.TitleMin, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationTitle))]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldTitle))]
        public string Title { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationDate))]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldDate))]
        public DateTime IncomeOn { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationAmount))]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldAmount))]
        public double Amount { get; set; }
        
        [StringLength(FieldsSizeCommonConst.NoteMax, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationNote))]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldNote))]
        public string? Note { get; set; }
        
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldIsActive))]
        public bool IsActive { get; set; }

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
