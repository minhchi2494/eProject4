using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class StoreSalesDetailServices : IStoreSalesDetailServices
    {
        public HttpClient _httpClient;

        public StoreSalesDetailServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrderDetail>> getStoreSalesDetails(DateTime? fromDate, DateTime? toDate)
        {
            var result = await _httpClient.GetFromJsonAsync<List<OrderDetail>>($"/api/StoreSalesDetail?fromDate={fromDate}&toDate={toDate}");
            return result;
        }
    }
}
