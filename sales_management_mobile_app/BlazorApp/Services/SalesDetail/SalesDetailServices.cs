using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class SalesDetailServices : ISalesDetailServices
    {
        public HttpClient _httpClient;

        public SalesDetailServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SalesDetail>> getSalesDetail(DateTime? fromDate, DateTime? toDate)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SalesDetail>>($"/api/SalesDetail?fromDate={fromDate}&toDate={toDate}");
            return result;
        }
    }
}
