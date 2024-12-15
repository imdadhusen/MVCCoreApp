using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveCategory
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.CategoryMax, MinimumLength = FieldsSizeCommonConst.CategoryMin, ErrorMessage = FieldsSizeCommonConst.CategoryMessage)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int Type { get; set; } = (int)EnumCategoryType.Expense; //1:Expense, 2:Income
        public bool IsStandard { get; set; } = false; 
    }
}
