using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class UserServices : IUserServices
    {
        public HttpClient _httpClient;

        public UserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> checkLogin(string username, string password)
        {
            var result = await _httpClient.PostAsJsonAsync($"/User?Username={username}/Password={password}", username);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<User>> getUsers(User searchUser)
        {
            var result = await _httpClient.GetFromJsonAsync<List<User>>($"api/User?Fullname={searchUser.Fullname}");
            return result;
        }
    
     
        public async Task<User> getUser(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<User>($"/api/User/{id}");
            return result;
        }

        public async Task<bool> createUser(User newUser)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/User", newUser);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateUser(User editUser)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/User", editUser);
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
