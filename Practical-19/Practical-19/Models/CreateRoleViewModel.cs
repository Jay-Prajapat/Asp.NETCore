using System.ComponentModel.DataAnnotations;

namespace Practical_19.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
