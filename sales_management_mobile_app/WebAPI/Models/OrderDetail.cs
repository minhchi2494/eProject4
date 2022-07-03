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
        public int ActualQuantity { get; set; } 

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}
