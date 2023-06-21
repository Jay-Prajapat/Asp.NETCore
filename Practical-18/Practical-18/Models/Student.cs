using System.ComponentModel.DataAnnotations;

namespace Practical_18.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public int Standard { get; set; }
        [Required]
        [StringLength(10),MinLength(10)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
         
    }
}
