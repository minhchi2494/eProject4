using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAPI.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int Inventory { get; set; }
        public DateTime DoM { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
