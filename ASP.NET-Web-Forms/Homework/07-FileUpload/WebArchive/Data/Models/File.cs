using System.ComponentModel.DataAnnotations;

namespace WebArchive.Data.Models
{
    public class File
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string ArchiveName { get; set; }
    }
}