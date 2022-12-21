using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class BudgetController : Controller
    {
        private readonly ILogger<BudgetController> _logger;

        public BudgetController(ILogger<BudgetController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}