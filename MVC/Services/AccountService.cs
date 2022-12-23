using Microsoft.Extensions.Caching.Memory;
using MVC.Helpers;
using MVC.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace MVC.Services
{
    public interface IAccountService
    {
        Task<bool> Register(RegisterViewModel model);
        Task<bool> Login(LoginViewModel model);              
    }

    public class AccountService : IAccountService
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IMemoryCache _memoryCache;
        private readonly AuthenticationSettings _authenticationSettings;
        public AccountService(IHttpClientHelper httpClientHelper, IMemoryCache memoryCache, AuthenticationSettings authenticationSettings)
        {
            _authenticationSettings = authenticationSettings;
            _httpClientHelper = httpClientHelper;
            _memoryCache = memoryCache;
        }

        private void AddTokenToCache(string token) 
        {
            _memoryCache.Set("access_token", token, TimeSpan.FromMinutes(_authenticationSettings.JwtExpireMinutes));
        }

        public async Task<bool> Login(LoginViewModel model)
        {
            var loginJson = JsonConvert.SerializeObject(model);
            var loginContent = new StringContent(loginJson, Encoding.UTF8, "application/json");

            var response = await _httpClientHelper.PostAsync("/account/login", loginContent);

            if (response.IsSuccessStatusCode)
            {
                var tokenData = await response.Content.ReadAsStringAsync();
                AddTokenToCache(tokenData);
                return true;
            }
            return false;
        }

        public async Task<bool> Register(RegisterViewModel model)
        {
            var registerJson = JsonConvert.SerializeObject(model);
            var registerContent = new StringContent(registerJson, Encoding.UTF8, "application/json");
            var response = await _httpClientHelper.PostAsync("/account/register", registerContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
