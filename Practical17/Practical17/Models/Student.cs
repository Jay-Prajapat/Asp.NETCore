using System.ComponentModel.DataAnnotations;

namespace Practical17.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Standard { get; set; }
        public int Age { get; set; }
    }
}
