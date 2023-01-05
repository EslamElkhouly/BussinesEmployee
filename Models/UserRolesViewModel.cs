using System.ComponentModel.DataAnnotations;

namespace BussinesEmployee.Models
{
    public class UserRolesViewModel
    {
        public UserRolesViewModel()
        {
            UsersName = new List<string>();
        }
        public string RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public List<string> UsersName { get; set; }

    }
}
