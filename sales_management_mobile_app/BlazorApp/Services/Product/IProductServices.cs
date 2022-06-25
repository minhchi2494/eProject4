using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp.Models;
using BlazorApp.Services.Request;
using Microsoft.AspNetCore.Http;

namespace BlazorApp.Services
{
    public interface IProductServices
    {
        Task<List<Product>> getProducts(Product searchProduct);
        Task<Product> getProduct(string id);
        Task<bool> createProduct(MultipartFormDataContent request);
        Task<bool> updateProduct(MultipartFormDataContent request);
    }
}
 