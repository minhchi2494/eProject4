using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class StoreUserServices : IStoreUserServices
    {
        public HttpClient _httpClient;

        public StoreUserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<vStoreUser>> getStoreUsers(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<vStoreUser>>($"/api/StoreUser/{id}");
            return result;
        }
    }
}
