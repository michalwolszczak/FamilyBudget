using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Helpers;
using MVC.Services;
using MVC.ViewModel;

namespace MVC.Controllers
{    
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _accountService.Register(model))
                {
                    return RedirectToAction("Login");
                }                
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _accountService.Login(model))
                {
                    return RedirectToAction("Index", "Budget");
                }                
            }
            return View(model);
        }
    }
}
