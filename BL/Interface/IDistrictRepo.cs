using BussinesEmployee.Models;

namespace BussinesEmployee.BL.Interface
{
    public interface IDistrictRepo
    {
        public IQueryable<DistrictVM> Get();

        public DistrictVM GetById(int id);
    }
}
