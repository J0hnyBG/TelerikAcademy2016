namespace CodeFirst.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Material
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
