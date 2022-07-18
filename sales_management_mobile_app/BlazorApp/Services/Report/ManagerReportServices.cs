using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class ManagerReportServices
    {
        public HttpClient _httpClient;

        public ManagerReportServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<vManagerReport>> getManagerReports()
        {
            var result = await _httpClient.GetFromJsonAsync<List<vManagerReport>>($"/api/ManagerReport");
            return result;
        }
    }
}
