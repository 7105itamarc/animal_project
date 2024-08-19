using _1907FirstWebAppAtempt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _1907FirstWebAppAtempt.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDetials model)
        {
            if (ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName!, model.password!, false, false);
                if (result.Succeeded)
                    return RedirectToAction("Administrator", "Main");
            }
            return View(); 
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("HomePage","Main");
        } 

       
        public async Task<IActionResult> Register()
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Administrators";
            await _roleManager.CreateAsync(role);

            IdentityUser user = new IdentityUser { UserName = "itamar" };
            var result = await _userManager.CreateAsync(user, "Itamar2001!!");
            await _userManager.AddToRoleAsync(user, "Administrators");


            if (result.Succeeded)
                return Content("Registertion Succided");
            return Content("Registration Failed");
        }


        public IActionResult AccessDenied()
        {
            return Content("Access denied - You have no access to this page!!!");
        }
    }
}
