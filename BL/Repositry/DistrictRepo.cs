using BussinesEmployee.BL.Interface;
using BussinesEmployee.DAL.Database;
using BussinesEmployee.Models;

namespace BussinesEmployee.BL.Repositry
{
    public class DistrictRepo :IDistrictRepo
    {

        private readonly DbContainer container;

        public DistrictRepo(DbContainer container)
        {
            this.container = container;
        }
        public IQueryable<DistrictVM> Get()
        {
            var districtName = container.District.Select(a => new DistrictVM { Id = a.Id, DistrictName = a.Name,CityId=a.CityId});
            return districtName;
        }

        public DistrictVM GetById(int id)
        {
            var data = container.District.Where(a => a.Id == id).Select(a => new DistrictVM{ Id = a.Id, DistrictName = a.Name, CityId = a.CityId }).FirstOrDefault();
            return data;
        }
    }
}
