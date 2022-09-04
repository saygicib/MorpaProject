using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(new UserLoginDto());
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserLoginDto());
        }
        [HttpPost]
        public IActionResult Login(UserLoginDto userDto)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Login(userDto))
                {
                    return RedirectToAction("Index","Home");
                }
                ViewData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı.";
                return View(userDto);
            }
            return View(userDto);

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new AddUserDto());
        }
        
        [HttpPost]
        public IActionResult Register(AddUserDto userDto)
        {
            if (ModelState.IsValid)
            {
                if (_userService.AddUser(userDto))
                {
                    return Json(true);
                }
                return Json(false);
            }
            return View(userDto);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
