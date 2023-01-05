using System.ComponentModel.DataAnnotations;

namespace BussinesEmployee.Models
{
    public class ForgetPasswordVM
    {

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }

        //public string Token { get; set; }
    }
}
