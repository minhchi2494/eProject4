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

        public Task<bool> createLoc(Location newLoc)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Location>> getAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Location>>($"/api/Location");
            return result;
        }

        public Task<List<Location>> getLocations(Location searchLoc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateLoc(Location editLoc)
        {
            throw new NotImplementedException();
        }
    }
}
