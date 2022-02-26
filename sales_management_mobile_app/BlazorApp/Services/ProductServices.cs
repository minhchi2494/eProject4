using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class ProductServices : IProductServices
    {
        public HttpClient _httpClient;

        public ProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> getProducts(Product searchProduct)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Product>>($"/api/Product?Name={searchProduct.Name}");
            return result;
        }

        public Task<Product> getProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> createProduct(Product createProduct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateProduct(Product editProduct)
        {
            throw new NotImplementedException();
        }
    }
}
