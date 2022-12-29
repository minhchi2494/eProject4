using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class DirectorServices : IDirectorServices
    {
        public HttpClient _httpClient;

        public DirectorServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public Task<Director> checkLogin(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<List<Director>> getDirectors(Director searchDirector)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Director>>($"api/Director?Fullname={searchDirector.Fullname}");
            return result;
        } 

        public async Task<Director> getDirector(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<Director>($"/api/Director/{id}");
            return result;
        }
         
        public async Task<bool> createDirector(MultipartFormDataContent newDirector)
        {
            var result = await _httpClient.PostAsync("/api/Director", newDirector);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateDirector(Director editDirector)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/Director", editDirector);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public Task<bool> createKpiValue(string dirId, int kpiValue)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
