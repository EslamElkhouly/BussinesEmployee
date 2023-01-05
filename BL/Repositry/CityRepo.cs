using BussinesEmployee.BL.Interface;
using BussinesEmployee.DAL.Database;
using BussinesEmployee.DAL.Entities;
using BussinesEmployee.Models;

namespace BussinesEmployee.BL.Repositry
{
    public class CityRepo :ICityRepo
    {
        private readonly DbContainer container;

        public CityRepo(DbContainer container)
        {
            this.container = container;
        }
        public IQueryable<CityVM> Get()
        {
            var citiesName = container.City.Select(a => new CityVM { Id = a.Id, CityName = a.CityName,CountryId= a.CountryId });
            return citiesName;
        }

        public CityVM GetById(int id)
        {
            var data = container.City.Where(a => a.Id == id).Select(a => new CityVM { Id = a.Id, CityName = a.CityName,CountryId=a.CountryId }).FirstOrDefault();
            return data;
        }
    }
}
