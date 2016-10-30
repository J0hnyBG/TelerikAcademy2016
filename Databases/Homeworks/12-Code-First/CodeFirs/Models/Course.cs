namespace CodeFirst.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
            this.Materials = new HashSet<Material>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
