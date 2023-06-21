using System.ComponentModel.DataAnnotations;

namespace Practical_18.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Standard { get; set; }

        [StringLength(10), MinLength(10)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
    }
}
