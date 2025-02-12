using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveExpenseReq
    {
        public int? Id { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [StringLength(FieldsSizeCommonConst.TitleMax, MinimumLength = FieldsSizeCommonConst.TitleMin, ErrorMessage = ResourceKey.ValidationTitle)]
        [Display(Name = ResourceKey.FieldTitle)]
        public string Title { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [DataType(DataType.Date, ErrorMessage = ResourceKey.ValidationDate)]
        [Display(Name = ResourceKey.FieldDate)]
        public DateTime ExpenseOn { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [Range(0, int.MaxValue, ErrorMessage = ResourceKey.ValidationAmount)]
        [Display(Name = ResourceKey.FieldAmount)]
        public double Amount { get; set; }

        [StringLength(FieldsSizeCommonConst.NoteMax, ErrorMessage = ResourceKey.ValidationNote)]
        [Display(Name = ResourceKey.FieldNote)]
        public string? Note { get; set; }

        [Display(Name = ResourceKey.FieldIsActive)]
        public bool IsActive { get; set; } = true;

        [Display(Name = ResourceKey.FieldAccount)]
        public int? AccountId { get; set; }

        [Display(Name = ResourceKey.FieldCategory)]
        public int? CategoryId { get; set; }

        [Display(Name = ResourceKey.FieldSubCategory)]
        public int? SubCategoryId { get; set; }

        [Display(Name = ResourceKey.FieldBulkImport)]
        public bool IsBulkImported { get; set; } = false;
    }
}
