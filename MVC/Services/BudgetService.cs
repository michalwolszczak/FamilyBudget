using Microsoft.Extensions.Configuration;
using MVC.Helpers;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Services
{
    public interface IBudgetService
    {
        Task<List<Budget>> GetBudgets();
    }
    public class BudgetService : IBudgetService
    {
        private readonly IHttpClientHelper _httpClientHelper;
        public BudgetService(IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        public async Task<List<Budget>> GetBudgets()
        {
            var budgets = new List<Budget>();

            var response = await _httpClientHelper.GetAsync("/budgets");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                budgets = JsonConvert.DeserializeObject<List<Budget>>(responseData);
            }

            return budgets;
        }
    }
}
