using Microsoft.AspNetCore.Http;

namespace WebAPI.Requests
{
    public class ProductRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public bool active { get; set; } = true;
        public IFormFile file { get; set; }
    }
}
