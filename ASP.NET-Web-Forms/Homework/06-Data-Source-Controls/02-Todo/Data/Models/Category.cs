using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _02_Todo.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Name { get; set; }
    }
}