using BussinesEmployee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace BussinesEmployee.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<IdentityUser> userManager ,SignInManager<IdentityUser> signInManager,ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }
        public IActionResult Registration()
        {
            return View();
        }
        
        
        [HttpPost]
               
        public async Task<IActionResult> Registration(RegistrationVM registrationVM)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser()
                {
                    UserName = registrationVM.Email,
                    Email=registrationVM.Email,
           
                };
               var result=await userManager.CreateAsync(identityUser, registrationVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
            }
            return RedirectToAction("Login"); 
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, loginVM.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(loginVM.Email);  
                    if (await userManager.IsInRoleAsync(user,"Admin"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (await userManager.IsInRoleAsync(user, "Basic"))
                    {
                        return RedirectToAction("Index", "BranchDefination",new {area="BasicInfo"});
                    }

                    

                }
                else
                {
                    ModelState.AddModelError(" ", "Invalid User Name Or Password");
                    
                }
            }
            return View(loginVM);
              
        }


        public async Task<IActionResult> Logout()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPasswordVM)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(forgetPasswordVM.Email);
                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordLink = Url.Action("ResetPassword", "Account", new { Email = user.Email, Token = token });
                    logger.Log(LogLevel.Warning, passwordLink);
                    return RedirectToAction("ConfirmForgetPassword","Account");
                }
            }
            return View(forgetPasswordVM);
        }
        public IActionResult ConfirmForgetPassword()
        {
          
            return View();
        }

        
        public IActionResult ResetPassword(string Email,string Token)
        {
            if (Email==null || Token==null)
            {
                ModelState.AddModelError(" ", "Invalid Data");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetForgetPasswordVM resetForgetPasswordVM)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(resetForgetPasswordVM.Email);
                if (user !=null)
                {
                    var result = await userManager.ResetPasswordAsync(user, resetForgetPasswordVM.Token, resetForgetPasswordVM.Password);
                    if(result.Succeeded) 
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }
                    
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(resetForgetPasswordVM);
                    
                }
               
            }
            
                return View(resetForgetPasswordVM);
            
        }
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }




        



    }
}
