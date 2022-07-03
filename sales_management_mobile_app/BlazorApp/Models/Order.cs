using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ActualQuantity { get; set; }

        [Required]
        public string StoreId { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public virtual Store Store { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
