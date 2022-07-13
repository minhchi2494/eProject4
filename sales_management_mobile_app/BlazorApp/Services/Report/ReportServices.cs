using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class ReportServices : IReportServices
    {
        public HttpClient _httpClient;

        public ReportServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Report>> getReports(DateTime? fromDate, DateTime? toDate)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Report>>($"/api/Report?fromDate={fromDate}&toDate={toDate}");
            return result;
        }
    }
}
