using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;
using BlazorApp.Services.Request;
using Microsoft.AspNetCore.Http;

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

        public async Task<Product> getProduct(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<Product>($"/api/Product/{id}");
            return result;
        }

        //public async Task<bool> createProduct(Product createProduct, System.IO.Stream image)
        public async Task<bool> createProduct(MultipartFormDataContent request)
        {

            //MultipartFormDataContent form = new MultipartFormDataContent();
            //form.Headers.ContentType.MediaType = "multipart/form-data";
            //form.Add(new StreamContent(image));
            //form.Add(new StringContent(JsonConvert.SerializeObject(createProduct), Encoding.UTF8, "application/json"));
            //var result1 = await _httpClient.PostAsync("/api/Product", form);

            //tạm thời comment
            //var result = await _httpClient.PostAsJsonAsync
            //    ($"/api/Product?Id={createProduct.Id}&Name={createProduct.Name}&Price={createProduct.Price}" +
            //    $"&Unit={createProduct.Unit}&Images={createProduct.Images}&IsActive={createProduct.IsActive}", createProduct);
            //if (result.IsSuccessStatusCode)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            var result = await _httpClient.PostAsync("/api/Product", request);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateProduct(MultipartFormDataContent request)
        {
            //var result = await _httpClient.PutAsJsonAsync
            //    ($"/api/Product?Id={editProduct.Id}&Name={editProduct.Name}&Price={editProduct.Price}" +
            //    $"&Unit={editProduct.Unit}&Images={editProduct.Images}&IsActive={editProduct.IsActive}", editProduct);
            var result = await _httpClient.PutAsync("/api/Product", request);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
