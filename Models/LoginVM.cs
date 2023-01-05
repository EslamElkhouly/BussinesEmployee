using BussinesEmployee.Resource.Account.Account_Login;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BussinesEmployee.Models
{
    public class LoginVM
    {
        [Required]
       
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
