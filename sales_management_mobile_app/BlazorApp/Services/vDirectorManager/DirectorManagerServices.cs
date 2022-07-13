using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class DirectorManagerServices : IDirectorManagerServices
    {
        public HttpClient _httpClient;

        public DirectorManagerServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<vDirectorManager>> getDirectorManagers(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<vDirectorManager>>($"/api/DirectorManager/{id}");
            return result;
        }
    }
}
