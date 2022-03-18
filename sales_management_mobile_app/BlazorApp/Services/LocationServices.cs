using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class LocationServices : ILocationServices
    {
        public HttpClient _httpClient;

        public LocationServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Location>> getLocations(Location searchLoc)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Location>>($"/api/Location?District={searchLoc.District}");
            return result;
        }

        public async Task<bool> createLoc(Location newLoc)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Location", newLoc);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateLoc(Location editLoc)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/Location", editLoc);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Location> getLocation(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Location>($"/api/Location/{id}");
            return result;
        }
    }
}
