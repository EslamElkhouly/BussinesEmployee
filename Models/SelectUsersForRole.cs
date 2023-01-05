
namespace BussinesEmployee.Models
{
    public class SelectUsersForRole
    {
        public SelectUsersForRole()
        {
            Checkboxes = new List<CheckboxViewModel>();
        }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
      
        public List<CheckboxViewModel> Checkboxes { get; set; }
    }
}
