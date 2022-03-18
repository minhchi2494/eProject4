using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class ManagerServices : IManagerServices
    {
        public HttpClient _httpClient;

        public ManagerServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Manager>> getManagers(Manager searchManager)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Manager>>($"/api/Manager?Fullname={searchManager.Fullname}");
            return result;
        }

        public async Task<Manager> getManager(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<Manager>($"/api/Manager/{id}");
            return result;
        }

        public async Task<bool> createManager(Manager newManager)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Manager", newManager);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateManager(Manager editManager)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/Manager", editManager);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
