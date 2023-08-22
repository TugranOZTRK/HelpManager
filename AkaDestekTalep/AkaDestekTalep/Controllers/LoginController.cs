using AkaDestekTalep.Models;
using Entity.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AkaDestekTalep.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (result.Succeeded)
            {
                // Kullanıcının rollerini alın
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Super Admin"))
                {
                    return RedirectToAction("YoneticiDestek", "Home");
                }
                else if (roles.Contains("Admin"))
                {
                    return RedirectToAction("DestekUzmani", "Home");
                }
                else if (roles.Contains("Departman Yöneticisi"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = new User
            {
                UserName = register.Email,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                FirstName = register.FirstName,
                LastName = register.LastName
            };
            var result = await _userManager.CreateAsync(user, register.Password);
            _userManager.AddToRoleAsync(user, "User");
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(register);
        }
    }
}
