using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace MVC.Helpers
{
    public interface IHttpClientHelper
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent httpContent);
    }
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseAddress;
        private readonly IMemoryCache _memoryCache;

        public HttpClientHelper(HttpClient httpClient, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _configuration = configuration;
            _httpClient = httpClient;
            _baseAddress = _configuration.GetValue<string>("APIBaseAddress");
        }

        private string GetBearerToken()
        {
            return _memoryCache.Get<string>("access_token");
        }

        private void AddBearerTokenToHttpClient()
        {
            var token = GetBearerToken();
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            AddBearerTokenToHttpClient();
            return await _httpClient.GetAsync(_baseAddress + requestUri);
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent httpContent)
        {
            AddBearerTokenToHttpClient();
            return await _httpClient.PostAsync(_baseAddress + requestUri, httpContent);
        }

    }
}
