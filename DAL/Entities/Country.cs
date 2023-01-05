using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinesEmployee.DAL.Entities
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string CountryName { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
