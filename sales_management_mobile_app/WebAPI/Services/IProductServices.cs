using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IProductServices
    {
        Task<List<Product>> getProducts(Product searchProduct);
        Task<Product> getProduct(string id);
        Task<bool> createProduct(Product createProduct);
        Task<bool> updateProduct(Product editProduct);
    }
}
