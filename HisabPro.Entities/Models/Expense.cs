﻿using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.Entities.Models
{
    public class Expense : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.TitleMax, MinimumLength = FieldsSizeCommonConst.TitleMin, ErrorMessage = FieldsSizeCommonConst.TitleMessage)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = FieldsSizeCommonConst.DateOnlyMessage)]
        public DateTime ExpenseOn { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = FieldsSizeCommonConst.NumberMessage)]
        public double Amount { get; set; }
        [StringLength(FieldsSizeCommonConst.NoteMax, ErrorMessage = FieldsSizeCommonConst.NoteMessage)]
        public string Note { get; set; }

        [ForeignKey("ParentCategoryId")]
        public ParentCategory ParentCategory { get; set; }
        public int ParentCategoryId { get; set; }

        [ForeignKey("ChildCategoryId")]
        public ChildCategory ChildCategory { get; set; }
        public int ChildCategoryId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
