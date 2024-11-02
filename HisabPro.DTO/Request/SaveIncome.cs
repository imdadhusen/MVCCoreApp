﻿using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveIncome
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.TitleMax, MinimumLength = FieldsSizeCommonConst.TitleMin, ErrorMessage = FieldsSizeCommonConst.TitleMessage)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = FieldsSizeCommonConst.DateOnlyMessage)]
        public DateTime IncomeOn { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = FieldsSizeCommonConst.NumberMessage)]
        public double Amount { get; set; }
        [StringLength(FieldsSizeCommonConst.NoteMax, ErrorMessage = FieldsSizeCommonConst.NoteMessage)]
        public string Note { get; set; }
        public bool IsActive { get; set; }

        public int? AccountId { get; set; }
    }
}