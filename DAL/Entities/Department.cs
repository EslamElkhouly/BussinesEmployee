
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BussinesEmployee.DAL.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }


        [StringLength(50)]
        public string DepartmentName{ get; set; }

        [StringLength(20)]
        public string DepartmentCode { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
