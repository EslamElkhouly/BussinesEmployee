using AutoMapper;
using BussinesEmployee.DAL.Entities;
using BussinesEmployee.Models;

namespace BussinesEmployee.BL.Mapper
{
    public class DomainProfile :Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();


            CreateMap<Employee, EmployeeVM>();  
            CreateMap<EmployeeVM, Employee>();
        }
        
    }
}
 