using BussinesEmployee.BL.Helper;
using BussinesEmployee.BL.Interface;
using BussinesEmployee.DAL.Entities;
using BussinesEmployee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;


namespace BussinesEmployee.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo employeeRepo;
        private readonly IDepartmentRepo departmentRepo;
        private readonly ICountryRepo countryRepo;
        private readonly ICityRepo cityRepo;
        private readonly IDistrictRepo districtRepo;

        public EmployeeController(IEmployeeRepo employeeRepo, IDepartmentRepo departmentRepo,ICountryRepo countryRepo, ICityRepo cityRepo, IDistrictRepo districtRepo)
        {
            this.employeeRepo = employeeRepo;
            this.departmentRepo = departmentRepo;
            this.countryRepo = countryRepo;
            this.cityRepo = cityRepo;
            this.districtRepo = districtRepo;
        }
      
        public IActionResult Index()
        {
            var emps = employeeRepo.GetAll();
            return View(emps);
        }


        public IActionResult Create()
        {
            var data = departmentRepo.Get();
            var country=countryRepo.Get();
            ViewBag.departmentList = new SelectList(data, "DepartmentId", "DepartmentName");

            ViewBag.CountryList = new SelectList(country, "Id", "CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM empVm)
        {
            var data = departmentRepo.Get();
            ViewBag.departmentList = new SelectList(data, "DepartmentId", "DepartmentName");

            try
            {
                if (ModelState.IsValid)
                {
                    employeeRepo.Add(empVm);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach (var modelstate in ModelState.Values)
                    {
                        foreach (var error in modelstate.Errors)
                        {
                            Console.WriteLine(error);
                        }

                    }
                    return View(empVm);
                }

            }
            catch (Exception)
            {

                foreach (var modelstate in ModelState.Values)
                {
                    foreach (var error in modelstate.Errors)
                    {
                        Console.WriteLine(error);
                    }

                }
                return View(empVm);
            }
          
        }




        public IActionResult Edit(int id)
        {
            var emp = employeeRepo.GetById(id);
            var data = departmentRepo.Get();
            ViewBag.items = new SelectList(data, "DepartmentId", "DepartmentName", emp.DepartmantId);
            var district = districtRepo.Get();
            ViewBag.DistrictList = new SelectList(district, "Id", "DistrictName",emp.DistrictId);
            var country = countryRepo.Get();
            ViewBag.CountryList = new SelectList(country, "Id", "CountryName");

           

            if (emp is null)
            {
                return View();
            }
            return View(emp);
        }



        [HttpPost]
        public IActionResult Edit(EmployeeVM empVm)
        {
            var data = departmentRepo.Get();
            ViewBag.items = new SelectList(data, "DepartmentId", "DepartmentName", empVm.DepartmantId);
            var district = districtRepo.Get();
            ViewBag.DistrictList = new SelectList(district, "Id", "DistrictName", empVm.DistrictId);
            var country = countryRepo.Get();
            ViewBag.CountryList = new SelectList(country, "Id", "CountryName");
            try
            {
                if (ModelState.IsValid)
                {
                    employeeRepo.Edit(empVm);
                    return RedirectToAction("Index", "Employee");
                }
                       
            }
            catch (Exception e)
            {
               
                return View(empVm);
            }
            return View(empVm);
        }


        
        public IActionResult Delete(int id)
        {
            try
            {
                employeeRepo.Delete(id);
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Invalid operation");
            }
            return RedirectToAction("Index","Employee");
        }


        //------------------------------------AJAX CALL-----------------------------------

        [HttpPost]
        public JsonResult GetCityNames(int countryId)
        {
          var data= cityRepo.Get().Where(a => a.CountryId == countryId);
            return Json(data);
        }




        [HttpPost]
        public JsonResult GetDistrictNames(int cityId)
        {
            var data = districtRepo.Get().Where(a => a.CityId == cityId);
            return Json(data);
        }

    }
}
