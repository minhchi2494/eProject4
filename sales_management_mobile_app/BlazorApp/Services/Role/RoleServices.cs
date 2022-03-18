using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class RoleServices : IRoleServices
    {
        public HttpClient _httpClient;

        public RoleServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Role>> getRoles(Role searchRole)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Role>>($"/api/Role?Title={searchRole.Title}");
            return result;
        }
        public async Task<Role> getRole(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Role>($"/api/Role/{id}");
            return result;
        }

        public async Task<bool> createRole(Role newRole)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Role", newRole);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateRole(Role editRole)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/Role", editRole);
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
