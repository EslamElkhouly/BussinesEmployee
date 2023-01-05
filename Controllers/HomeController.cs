using BussinesEmployee.BL.Interface;
using BussinesEmployee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BussinesEmployee.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDataRepo dataRepo;

        public HomeController(IDataRepo dataRepo)
        {
            this.dataRepo = dataRepo;
        }
        public IActionResult Index()
        {
            var model = new DataViewModel()
            {
                DepartmentNumber = dataRepo.GetTotaldepartmentNumber(),
                EmployeeNumber = dataRepo.GetTotalEmployeeNumers(),
                RolesNumber=dataRepo.GetTotalRolesNumber()
            };
            return View(model);
        }

      

        
    }
}
