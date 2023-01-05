using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinesEmployee.DAL.Entities
{
    [Table("City")]
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string CityName { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country{ get; set; }

        public virtual ICollection<District> District { get; set; }
    }
}
