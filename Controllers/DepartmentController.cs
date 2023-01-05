using BussinesEmployee.BL.Interface;
using BussinesEmployee.BL.Repositry;
using BussinesEmployee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BussinesEmployee.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo dptRepo;
        public DepartmentController(IDepartmentRepo dptRepo)
        {
            this.dptRepo = dptRepo;
        }
      
        public IActionResult Index()
        {

           
            var dpt = dptRepo.Get();

            return View(dpt);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM dpt)
        {
            if (!ModelState.IsValid)
            {
                return View(dpt);
            }
            try
            {

                dptRepo.Add(dpt);
                return RedirectToAction("Index", "Department");
            }
            catch (Exception)
            {

                return View(dpt);
            }
           
        }

        public IActionResult Edit(int id)
        {
           var dpt= dptRepo.GetById(id);
            if (dpt is null)
            {
                return View();
            }
            return View(dpt);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM dptVm)
        {
            if (ModelState.IsValid)
            {
                dptRepo.Edit(dptVm);
                return RedirectToAction("Index", "Department");
            }
            return View(dptVm);
        }

        public IActionResult Delete(int id)
        {
            dptRepo.Delete(id);
            return RedirectToAction("Index", "Department");
        }

    }
}
