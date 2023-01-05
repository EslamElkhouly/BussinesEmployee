using AutoMapper;
using BussinesEmployee.BL.Interface;
using BussinesEmployee.DAL.Database;
using BussinesEmployee.DAL.Entities;
using BussinesEmployee.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinesEmployee.BL.Repositry
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DbContainer dbContainer;
        private readonly IMapper mapper;

        public DepartmentRepo(DbContainer dbContainer ,IMapper mapper)
        {
           this.dbContainer = dbContainer;
            this.mapper = mapper;
        }

        public void Add(DepartmentVM dpt)
        {
            // Department d = new Department() { DepartmentName = dpt.DepartmentName, DepartmentCode = dpt.DepartmentCode };

           var data= mapper.Map<Department>(dpt);
            dbContainer.Department.Add(data);
            dbContainer.SaveChanges();
        }

        public void Delete(int departmentId)
        {
            var dp = dbContainer.Department.Find(departmentId);
            dbContainer.Department.Remove(dp);
            dbContainer.SaveChanges();
        }

        public void Edit(DepartmentVM dptVm)
        {
            var data = mapper.Map<Department>(dptVm);
            dbContainer.Entry(data).State = EntityState.Modified;
            dbContainer.SaveChanges();

        }

        public IQueryable<DepartmentVM> Get()
        {
            return this.dbContainer.Department.Select(a => new DepartmentVM { DepartmentId = a.DepartmentId, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
        }

        public DepartmentVM GetById(int departmentId)
        {
            var dptInDb = dbContainer.Department.Where(a => a.DepartmentId == departmentId)
                .Select(a => new DepartmentVM { DepartmentId = a.DepartmentId, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                .FirstOrDefault();
            return dptInDb;
        }
    }
}
