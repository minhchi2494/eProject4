using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace BlazorApp.Services.Request
{
    public class ProductRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public bool? active { get; set; }
        public MultipartFormDataContent file { get; set; }
    }
}
