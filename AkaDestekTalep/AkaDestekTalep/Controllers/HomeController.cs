using AkaDestekTalep.Models;
using Business.Managers;
using Data.EfRepository;
using Entity.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AkaDestekTalep.Controllers
{
    public class HomeController : Controller
    {
        DestekTurManager _destekTurManager = new DestekTurManager(new EfDestekTurRepository());
        DestekKonuManager _destekKonuManager = new DestekKonuManager(new EfDestekKonuRepository());
        DestekManager _destekManager = new DestekManager(new EfDestekRepository());
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DestekAl()
        {
            var turler = _destekTurManager.GetList();
            var konular = _destekKonuManager.GetList();
            var adminler = _userManager.GetUsersInRoleAsync("Admin").Result;
            var model = new DestekAlViewModel
            {
                Konular = konular,
                Turler = turler,
                Adminler = adminler
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> DestekAl(DestekAlViewModel model)
        {
            var user = await _userManager.FindByIdAsync(User.Identity.Name);
            var destek = new Destek
            {
               DestekAlanId = user.Id,
               DestekKonuId = model.SecilenKonu,
               DestekVerenId = model.SecilenAdmin,
               OlusturmaTarihi = DateTime.Now,
               Acklama = model.Aciklama
            };
            _destekManager.Add(destek);
            return RedirectToAction("Index","Home");
        }
        public IActionResult Taleplerim()
        {
            return View();
        }
        public IActionResult DestekAlDiger()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}