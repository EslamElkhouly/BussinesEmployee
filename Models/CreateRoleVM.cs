using System.ComponentModel.DataAnnotations;

namespace BussinesEmployee.Models
{
    public class CreateRoleVM
    {
        public string  RoleId { get; set; }

        [Required,MinLength(3),MaxLength(100)]
        public string RoleName { get; set; }
    }
}
