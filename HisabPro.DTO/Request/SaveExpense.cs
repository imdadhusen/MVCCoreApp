﻿using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveExpense
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.TitleMax, MinimumLength = FieldsSizeCommonConst.TitleMin, ErrorMessage = FieldsSizeCommonConst.TitleMessage)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = FieldsSizeCommonConst.DateOnlyMessage)]
        [Display(Name = "Date")]
        public DateTime ExpenseOn { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = FieldsSizeCommonConst.NumberMessage)]
        public double Amount { get; set; }
        [StringLength(FieldsSizeCommonConst.NoteMax, ErrorMessage = FieldsSizeCommonConst.NoteMessage)]
        public string Note { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Account")]
        public int? AccountId { get; set; }
        [Display(Name = "Category")]
        public int? ParentCategoryId { get; set; }
        [Display(Name = "Sub Category")]
        public int? ChildCategoryId { get; set; }
    }
}
