﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.Entities.Models
{
    public class ChildCategory : AuditableEntity, ICategorySave, ICategoryDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Name { get; set; }
        [ForeignKey("ParentCategoryId")]
        public ParentCategory ParentCategory { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
