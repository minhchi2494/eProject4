using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class TargetServices : ITargetServices
    {
        public HttpClient _httpClient;

        public TargetServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Target>> getTargets(DateTime? fromDate, DateTime? toDate)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Target>>($"/api/Target?fromDate={fromDate}&toDate={toDate}");
            return result;
        }


    }
}
