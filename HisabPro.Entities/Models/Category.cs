﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HisabPro.Constants;

namespace HisabPro.Entities.Models
{
    public class Category : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.CategoryMax, MinimumLength = FieldsSizeCommonConst.CategoryMin, ErrorMessage = FieldsSizeCommonConst.CategoryMessage)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }
        public int Type { get; set; } = 1; // Example values: "2:Income", "1:Expense"
        public bool IsStandard { get; set; } = false; // True for system-created, False for user-created
        public virtual ICollection<Category> SubCategories { get; set; }
        
        public Category()
        {
            SubCategories = new HashSet<Category>();
        }
    }
}
