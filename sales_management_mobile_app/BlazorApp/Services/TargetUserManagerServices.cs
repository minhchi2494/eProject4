using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class TargetUserManagerServices : ITargetUserManagerServices
    {
        public HttpClient _httpClient;

        public TargetUserManagerServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<vTargetUserManager>> getTargetUserManagers(DateTime? fromDate, DateTime? toDate)
        {
            var result = await _httpClient.GetFromJsonAsync<List<vTargetUserManager>>($"/api/TargetUserManager?fromDate={fromDate}&toDate={toDate}");
            return result;
        }
    }
}
