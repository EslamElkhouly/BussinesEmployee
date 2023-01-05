using BussinesEmployee.BL.Interface;
using BussinesEmployee.DAL.Database;
using BussinesEmployee.DAL.Entities;
using BussinesEmployee.Models;

namespace BussinesEmployee.BL.Repositry
{
    public class CountryRepo : ICountryRepo
    {
        private readonly DbContainer container;

        public CountryRepo(DbContainer container)
        {
            this.container = container;
        }
        public IQueryable<CountryVM> Get()
        {
            var countriesName = container.Country.Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName });
            return countriesName;
        }

        public CountryVM GetById(int id)
        {
            var data = container.Country.Where(a => a.Id == id).Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName }).FirstOrDefault();
            return data;
        }
    }
}
