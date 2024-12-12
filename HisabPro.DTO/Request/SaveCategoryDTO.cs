using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveCategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.CategoryMax, MinimumLength = FieldsSizeCommonConst.CategoryMin, ErrorMessage = FieldsSizeCommonConst.CategoryMessage)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
