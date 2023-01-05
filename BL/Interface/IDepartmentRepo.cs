using BussinesEmployee.DAL.Entities;
using BussinesEmployee.Models;

namespace BussinesEmployee.BL.Interface
{
    public interface IDepartmentRepo
    {
        public IQueryable<DepartmentVM> Get();
        public void Add(DepartmentVM dpt);
        public void Delete(int departmentId);
        public void Edit(DepartmentVM dptVm);
        public DepartmentVM GetById(int departmentId);
    }
}
