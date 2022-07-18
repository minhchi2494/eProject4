using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class DirectorReportServices
    {
        public HttpClient _httpClient;

        public DirectorReportServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<vDirectorReport>> getDirectorReports()
        {
            var result = await _httpClient.GetFromJsonAsync<List<vDirectorReport>>($"/api/DirectorReport");
            return result;
        }
    }
}
