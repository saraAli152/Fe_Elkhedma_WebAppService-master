using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewWeppAppServices2.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="نوع الخدمه")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "وصف النوع")]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Serve> Serves { get; set; } 
    }
}