using BussinesEmployee.Models;

namespace BussinesEmployee.BL.Interface
{
    public interface ICityRepo
    {
        public IQueryable<CityVM> Get();
        public CityVM GetById(int id);
    }
}
