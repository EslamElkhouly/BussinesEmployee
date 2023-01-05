using BussinesEmployee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BussinesEmployee.Controllers
{

    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult CreateRole()
        {
            return View();
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(EditRoleVM model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(" ", "Invalid Name");
                return View(model);
            }

            var roles =await roleManager.FindByNameAsync(model.RoleName);
            if (roles != null)
            {
                ModelState.AddModelError(" ", "Role Already Created");
            }
            var result = await roleManager.CreateAsync(new IdentityRole(model.RoleName));
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return View("Error");
            }
            var model = new UserRolesViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name
            };
            foreach (var user in userManager.Users.ToList())
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.UsersName.Add(user.UserName);
                }
            }
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(UserRolesViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
            {
                return View("Error");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View(model);
            }

        }



        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ModelState.AddModelError("", "There is no Role with this Name");
                return View("Edit", "Admin");
            }
            var model = new SelectUsersForRole()
            {
                RoleId = roleId,
                RoleName = role.Name
            };
            foreach (var user in userManager.Users.ToList())
            {
                var checkbox = new CheckboxViewModel()
                {
                    Id = user.Id,
                    DisplayName = user.UserName,
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    checkbox.IsSelected = true;
                }
                else
                {
                    checkbox.IsSelected = false;
                }


                model.Checkboxes.Add(checkbox);
            }
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(SelectUsersForRole model)
        {
            var role = await roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
            {
                ModelState.AddModelError("", "There is no Role with this Name");
                return View("Edit", "Admin");
            }
            for (int i = 0; i < model.Checkboxes.Count; i++)
            {
                var userInDb = await userManager.FindByIdAsync(model.Checkboxes[i].Id);

                var result = await userManager.IsInRoleAsync(userInDb, role.Name);

                IdentityResult identityResult = null;

                if (result && !model.Checkboxes[i].IsSelected)
                {
                    identityResult = await userManager.RemoveFromRoleAsync(userInDb, role.Name);
                    
                }

               else if (!result && model.Checkboxes[i].IsSelected)
                {

                    identityResult = await userManager.AddToRoleAsync(userInDb, role.Name);
                }

               
                    if (i<(model.Checkboxes.Count-1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                
              
            }

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ModelState.AddModelError(" ", "Invalid Role ");
                return RedirectToAction("Index");
            }
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(" ", error.Description);
            }
            return View("index");
        }


        //For Testing 
        public async  Task<IActionResult> Test(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ModelState.AddModelError("", "There is no Role with this Name");
                return View("Edit", "Admin");
            }
            var model = new SelectUsersForRole()
            {
                RoleId = roleId,
                RoleName = role.Name
            };
            foreach (var user in userManager.Users.ToList())
            {
                var checkbox = new CheckboxViewModel()
                {
                    Id = user.Id,
                    DisplayName = user.UserName,
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    checkbox.IsSelected = true;
                }
                else
                {
                    checkbox.IsSelected = false;
                }


                model.Checkboxes.Add(checkbox);
            }
            return View(model);
        }



    }
}
