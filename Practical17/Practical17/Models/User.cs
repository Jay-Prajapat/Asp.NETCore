using System.ComponentModel.DataAnnotations;

namespace Practical17.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Mobile Number")]
        [StringLength(10,MinimumLength =10)]
        public string MobileNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public virtual Role Roles { get; set; }
    }
}
