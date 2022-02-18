using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;
namespace BlazorApp.Services
{
    public class AdminServices : IAdminServices
    {
        public HttpClient _httpClient;

        public AdminServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Admin> checkLogin(string username, string password)
        {
            var result = await _httpClient.GetFromJsonAsync<Admin>($"/api/Admin/{username}/{password}");
            return result;
        }

        public async Task<List<Admin>> getAdmins()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Admin>>($"/api/Admin");
            return result;
        }

        public async Task<Admin> getAdmin(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Admin>($"/api/Admin/{id}");
            return result;
        }

        public Task<bool> createAdmin(Admin newAdmin)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateAdmin(Admin editAdmin)
        {
            throw new NotImplementedException();
        }
    }
}
