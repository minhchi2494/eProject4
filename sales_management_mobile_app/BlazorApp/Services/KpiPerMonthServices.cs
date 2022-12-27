using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class KpiPerMonthServices
    {
        public HttpClient _httpClient;

        public KpiPerMonthServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<vKpiPerMonth>> getAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<vKpiPerMonth>>($"/api/KpiPerMonth");
            return result;
        }
    }
}
