using BussinesEmployee.Models;

namespace BussinesEmployee.BL.Interface
{
    public interface IEmployeeRepo
    {
        public void Add(EmployeeVM empVM);
        

        public EmployeeVM GetById(int id);

        public void Edit(EmployeeVM empVM);

        public void Delete(int id);

        public IQueryable<EmployeeVM> GetAll();

    }
}
