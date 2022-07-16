using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class UserStoreServices : IUserStoreServices
    {
        public HttpClient _httpClient;

        public UserStoreServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<vUserStore>> getUserStores(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<vUserStore>>($"/api/UserStore/{id}");
            return result;
        }
    }
}
