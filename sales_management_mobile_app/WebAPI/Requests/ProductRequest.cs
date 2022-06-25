using Microsoft.AspNetCore.Http;

namespace WebAPI.Requests
{
    public class ProductRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public decimal price { get; set; }
        public bool active { get; set; }
        public IFormFile file { get; set; }
    }
}
