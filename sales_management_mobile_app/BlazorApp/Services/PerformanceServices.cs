using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class PerformanceService : IPerformanceService
    {
        public HttpClient _httpClient;

        public PerformanceService(HttpClient context)
        {
            _httpClient = context;
        }



        public Task<List<Performance>> getAll()
        {
            var result = _httpClient.GetFromJsonAsync<List<Performance>>($"/api/TargetUserManager");

            return result;
        }


       
    }
}
