namespace MVC.Models
{
    public class BudgetService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public BudgetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("APIBaseAddress"));
        }
    }
}
