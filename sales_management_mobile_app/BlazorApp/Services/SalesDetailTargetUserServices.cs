using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class SalesDetailTargetUserServices : ISalesDetailTargetUser
    {
        public HttpClient _httpClient;

        public SalesDetailTargetUserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<vSalesDetailTargetUser>> getSalesDetailTargetUsers(DateTime? fromDate, DateTime? toDate)
        {
            var result = await _httpClient.GetFromJsonAsync<List<vSalesDetailTargetUser>>($"/api/SalesDetailTargetUser?fromDate={fromDate}&toDate={toDate}");
            return result;
        }
    }
}
