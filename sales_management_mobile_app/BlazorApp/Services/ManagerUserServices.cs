using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class ManagerUserServices : IManagerUserServices
    {
        public HttpClient _httpClient;

        public ManagerUserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<vManagerUser>> getManagerUsers(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<vManagerUser>>($"/api/ManagerUser/{id}");
            return result;
        }
    }
}
