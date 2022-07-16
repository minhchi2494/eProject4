using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ProductServices : IProductServices
    {
        private readonly Project4Context _context;

        public ProductServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<Product>> getProducts(Product searchProduct)
        {
            var result = _context.Products.Where(x=>x.IsActive == true).ToList();
            if (!string.IsNullOrEmpty(searchProduct.Name))
            {
                result = result.Where(x => x.Name.ToLower().Contains(searchProduct.Name.ToLower())).ToList();
            }
            return result;
        }

        public async Task<bool> createProduct(Product createProduct)
        {
            var result = _context.Products.SingleOrDefault(x => x.Id.Equals(createProduct.Id));
            if (result == null)
            {
                _context.Products.Add(createProduct);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Product> getProduct(string id)
        {
            var result = _context.Products.SingleOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> updateProduct(Product editProduct)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id.Equals(editProduct.Id));
            if (product != null)
            {
                product.Name = editProduct.Name;
                product.Price = editProduct.Price;
                product.Images = editProduct.Images;
                product.Description = editProduct.Description;
                product.IsActive = editProduct.IsActive;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
