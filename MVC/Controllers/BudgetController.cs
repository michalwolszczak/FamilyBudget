using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Services;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class BudgetController : Controller
    {
        private readonly ILogger<BudgetController> _logger;
        private readonly IBudgetService _budgetService;
        public BudgetController(ILogger<BudgetController> logger, IBudgetService budgetService)
        {
            _budgetService = budgetService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var budgets = await _budgetService.GetBudgets();
            return View(budgets);
        }
    }
}