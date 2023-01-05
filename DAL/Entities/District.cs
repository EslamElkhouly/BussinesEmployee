using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinesEmployee.DAL.Entities
{
    public class District

    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }


        public virtual ICollection<Employee> Employee{ get; set; }

    }
}
