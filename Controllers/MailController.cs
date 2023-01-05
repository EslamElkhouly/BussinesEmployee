using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Security;

namespace BussinesEmployee.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SendMail(string title,string body)
        {
            try
            {

                //replace host with proper domain ex:smtp-mail.outlook.com
                // replace 000 with proper port ex: 587
                SmtpClient smtp = new SmtpClient("host", 000);
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
               
                //credentials
                smtp.Credentials = new NetworkCredential("userName", "Password");
              
               
                smtp.Send("From", "To", title, body);
                TempData["message"] = "Email has been sent";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                TempData["message"] = "Email Failed to sent ";
            }
            return RedirectToAction("Index");

        }

        public IActionResult MailBox()
        {
            return View();
        }
    }
}
