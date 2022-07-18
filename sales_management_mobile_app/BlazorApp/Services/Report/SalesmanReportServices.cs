using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class SalesmanReportServices
    {
        public HttpClient _httpClient;

        public SalesmanReportServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<vSalesmanReport>> getSalesmanReports()
        {
            var result = await _httpClient.GetFromJsonAsync<List<vSalesmanReport>>($"/api/SalesmanReport");
            return result;
        }
    }
}
