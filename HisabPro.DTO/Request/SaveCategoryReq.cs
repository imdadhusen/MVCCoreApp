using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveCategoryReq
    {
        public int? Id { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [StringLength(FieldsSizeCommonConst.CategoryMax, MinimumLength = FieldsSizeCommonConst.CategoryMin, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationCategory))]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldName))]
        public string Name { get; set; }
        
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldParentCategory))]
        public int? ParentId { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldType))]
        public int Type { get; set; } = (int)EnumCategoryType.Expense; //1:Expense, 2:Income
        
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldIsStandard))]
        public bool IsStandard { get; set; } = false; 
    }
}
