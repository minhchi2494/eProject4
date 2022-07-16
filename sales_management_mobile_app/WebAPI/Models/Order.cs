using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int ActualQuantity { get; set; }
        public string StoreId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public virtual Store Store { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
