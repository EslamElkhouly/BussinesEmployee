using AutoMapper;
using BussinesEmployee.BL.Interface;
using BussinesEmployee.DAL.Database;
using BussinesEmployee.Models;
using BussinesEmployee.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using BussinesEmployee.BL.Helper;

namespace BussinesEmployee.BL.Repositry
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DbContainer context;
        private readonly IMapper mapper;
        public EmployeeRepo(DbContainer context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void Add(EmployeeVM empVM)
        {
            
            var data = mapper.Map<Employee>(empVM);
            if (empVM.CVUrl != null)
            {
                data.CVName = UploadFileHelper.SaveFile(empVM.CVUrl, "/Docs");

            }
            if (empVM.PhotoUrl != null)
            {
                data.PhotoName = UploadFileHelper.SaveFile(empVM.PhotoUrl, "/Photos");
            }
            
         

            context.Employee.Add(data);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = context.Employee.Find(id);
            if (data != null)
            {
                try
                {
                    context.Employee.Remove(data);
                    UploadFileHelper.RemoveFile(data.PhotoName, "Photos");
                    UploadFileHelper.RemoveFile(data.CVName, "Docs");

                }
                catch (Exception)
                {

                    throw;
                }
                context.SaveChanges();
            }
        }

        public void Edit(EmployeeVM empVM)
        {
            if (empVM.PhotoUrl != null)
            {
                UploadFileHelper.RemoveFile(empVM.PhotoName, "Photos");
                empVM.PhotoName = UploadFileHelper.SaveFile(empVM.PhotoUrl, "/Photos");
            }

            if (empVM.CVUrl != null)
            {
                UploadFileHelper.RemoveFile(empVM.CVName, "Docs");
                empVM.CVName = UploadFileHelper.SaveFile(empVM.CVUrl, "/Docs");
            }


            var data = mapper.Map<Employee>(empVM);
            context.Entry(data).State = EntityState.Modified;
            context.SaveChanges();

        }

        public IQueryable<EmployeeVM> GetAll()
        {
            var data = context.Employee.Select(a => new EmployeeVM
            {
                EmployeeId = a.EmployeeId,
                EmployeeName = a.EmployeeName,
                Salary = a.Salary,
                Address = a.Address,
                Email = a.Email,
                HireDate = a.HireDate,
                IsActive = a.IsActive,
                Notes = a.Notes,
                DepartmantId = a.Department.DepartmentName,
                DistrictId = a.District.Name,
                PhotoName = a.PhotoName,
                CVName = a.CVName
            }) ;
            return data;
        }




        public EmployeeVM GetById(int id)
        {
            var data = context.Employee.Find(id);
            var emp = mapper.Map<EmployeeVM>(data);
            return emp;
        }
    }
}
