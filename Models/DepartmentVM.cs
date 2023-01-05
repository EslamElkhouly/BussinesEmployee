using System.ComponentModel.DataAnnotations;

namespace BussinesEmployee.Models
{
    public class DepartmentVM
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="Department Name is Rquired")]
        [MaxLength(20, ErrorMessage = "Max Length is 20 charachter")]
        [MinLength(3, ErrorMessage = "Min Length is 3 charachter")]
        public string DepartmentName { get; set; }


        [Required(ErrorMessage = "Department Code is Rquired")]
        [MaxLength(20, ErrorMessage = "Max Length is 20 charachter")]
        [MinLength(3, ErrorMessage = "Min Length is 3 charachter")]
        public string DepartmentCode { get; set; }

    

    }
}
