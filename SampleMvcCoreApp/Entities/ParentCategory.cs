﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleMvcCoreApp.Entities
{
    public class ParentCategory : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ChildCategory> ChildCategories { get; set; }
                
        public ParentCategory()
        {
            //Collection is initialized properly to avoid null reference issues.
            ChildCategories = new List<ChildCategory>();
        }
    }
}
