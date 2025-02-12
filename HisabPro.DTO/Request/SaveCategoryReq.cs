using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveCategoryReq
    {
        public int? Id { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [StringLength(FieldsSizeCommonConst.CategoryMax, MinimumLength = FieldsSizeCommonConst.CategoryMin, ErrorMessage = ResourceKey.ValidationCategory)]
        [Display(Name = ResourceKey.FieldName)]
        public string Name { get; set; }

        [Display(Name = ResourceKey.FieldParentCategory)]
        public int? ParentId { get; set; }

        [Display(Name = ResourceKey.FieldType)]
        public int Type { get; set; } = (int)EnumCategoryType.Expense; //1:Expense, 2:Income

        [Display(Name = ResourceKey.FieldIsStandard)]
        public bool IsStandard { get; set; } = false;
    }
}
