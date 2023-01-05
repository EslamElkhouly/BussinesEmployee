using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BussinesEmployee.Models
{
    public class RegistrationVM
    {

        //[Required]
        //public string UserName { get; set; }

        [Required(ErrorMessage ="Email Required")]
        [EmailAddress]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password IS Required")]
        [MinLength(6,ErrorMessage ="min lenth is 6")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password IS Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "min lenth is 6")]
        [Compare("Password",ErrorMessage ="Password Does not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
