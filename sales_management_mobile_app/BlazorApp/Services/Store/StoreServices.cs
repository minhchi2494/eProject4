using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class StoreServices : IStoreServices
    {
        public HttpClient _httpClient;

        public StoreServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Store>> getStores(Store searchStore)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Store>>($"/api/Store?Name={searchStore.Name}");
            return result;
        }

        public async Task<Store> getStore(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<Store>($"/api/Store/{id}");
            return result;
        }

        public async Task<bool> createStore(Store newStore)
        {
            var result = await _httpClient.PostAsJsonAsync($"/api/Store?Id={newStore.Id}&Name={newStore.Name}" +
                $"&Email={newStore.Email}&Phone={newStore.Phone}&Address={newStore.Address}&Longitude={newStore.Longitude}" +
                $"&Latitude={newStore.Latitude}&IsActive={newStore.IsActive}&UserId={newStore.UserId}", newStore);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateStore(Store editStore)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/Store?Id={editStore.Id}&Name={editStore.Name}" +
                $"&Email={editStore.Email}&Phone={editStore.Phone}&Address={editStore.Address}" +
                $"&IsActive={editStore.IsActive}", editStore);
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
