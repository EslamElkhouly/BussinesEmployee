using BussinesEmployee.Models;
namespace BussinesEmployee.BL.Interface
{
    public interface ICountryRepo
    {
        public IQueryable<CountryVM> Get();
        public CountryVM GetById(int id);
    }
}
