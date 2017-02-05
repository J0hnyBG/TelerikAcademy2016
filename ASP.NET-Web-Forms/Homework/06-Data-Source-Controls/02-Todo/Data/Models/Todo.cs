using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_Todo.Data.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Body { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}