using System.ComponentModel.DataAnnotations;

namespace BussinesEmployee.Models
{
    public class EditRoleVM
    {

        [Required, MinLength(3), MaxLength(100)]
        public string RoleName { get; set; }
    }
}
