using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int OrderId { get; set; }

        public double Price { get; set; }

        public int ActualQuantity { get; set; } 

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }

        public OrderDetail(string ProductId, int OrderId, double Price, int ActualQuantity)
        {
            this.ProductId = ProductId;
            this.OrderId = OrderId;
            this.Price = Price;
            this.ActualQuantity = ActualQuantity;
        }

        public OrderDetail() { }
    }
}
