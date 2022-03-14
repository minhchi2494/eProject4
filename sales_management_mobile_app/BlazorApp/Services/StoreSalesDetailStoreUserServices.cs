using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class StoreSalesDetailStoreUserServices : IStoreSalesDetailStoreUserServices
    {
        public HttpClient _httpClient;

        public StoreSalesDetailStoreUserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<vStoreSalesDetailStoreUser>> getStoreSalesDetailStoreUsers(DateTime? fromDate, DateTime? toDate)
        {
            var result = await _httpClient.GetFromJsonAsync<List<vStoreSalesDetailStoreUser>>($"/api/StoreSalesDetailStoreUser?fromDate={fromDate}&toDate={toDate}");
            return result;
        }
    }
}
