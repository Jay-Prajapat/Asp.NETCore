using System.ComponentModel.DataAnnotations;

namespace Practical_20.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$",ErrorMessage ="Phone number must be 10 degits.")]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
