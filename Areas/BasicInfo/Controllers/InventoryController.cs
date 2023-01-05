using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BussinesEmployee.Areas.BasicInfo.Controllers
{
    [Authorize(Roles = "Basic")]
    public class InventoryController : Controller
    {
        [Area("BasicInfo")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
