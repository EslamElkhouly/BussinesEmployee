using System.ComponentModel.DataAnnotations;


namespace BussinesEmployee.Models
{
    public class ResetForgetPasswordVM
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }

        public string Token { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is equired")]
        [MinLength(6, ErrorMessage = "min lenth is 6")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "min lenth is 6")]
        [Compare("Password", ErrorMessage = "Password Does not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
