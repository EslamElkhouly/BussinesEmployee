using BussinesEmployee.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BussinesEmployee.Models
{
    public class EmployeeVM
    {
        public int EmployeeId { get; set; }


       [Required(ErrorMessage ="Enter your Name")]
        [MinLength(3,ErrorMessage ="min length 3")]
        [MaxLength(50, ErrorMessage = "Max length 5")]
        [DisplayName("Name")]
        public string EmployeeName { get; set; }


        [Required(ErrorMessage ="Salary is required")]
        [Range(3000,10000,ErrorMessage ="Salarymust be between 3000 and 10000")]
        public float Salary { get; set; }


        [Required(ErrorMessage ="address is Required")]
    //    [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3-50}-[a-zA-Z]{3-50}-[a-zA-Z]{3-50}", ErrorMessage ="Example 12-StreatName-CityName-CountryName")]
        public string Address { get; set; }


        [EmailAddress]
        public string Email { get; set; }


        [DisplayName("Hire Date")]
        public DateTime HireDate { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        
        public string Notes { get; set; }

        public IFormFile? PhotoUrl { get; set; }

        public string? PhotoName { get; set; }
        public string? CVName { get; set; }
        public IFormFile? CVUrl { get; set; }
        public string DepartmantId { get; set; }

        public string DistrictId { get; set; }


    }
}
