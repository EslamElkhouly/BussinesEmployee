using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinesEmployee.DAL.Entities
{

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }


       [StringLength(50)]
        public string EmployeeName { get; set; }

        public float Salary { get; set; }

        public string Address { get; set; }


        public string  Email { get; set; }
        public DateTime  HireDate { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }

        public int DepartmantId { get; set; }

        [ForeignKey("DepartmantId")]
        public Department Department { get; set; }


        
        public string? PhotoName { get; set; }
        public string? CVName { get; set; }


        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public District District { get; set; }
    }
}
