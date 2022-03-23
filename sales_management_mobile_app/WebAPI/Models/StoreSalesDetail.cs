using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public class StoreSalesDetail
    {
        public int Id { get; set; }
        //public int? QuantityCommit { get; set; }
        //public int? SalesDetailId { get; set; }
        public string ProductId { get; set; }
        //public decimal? Price { get; set; }
        public DateTime Date { get; set; }
        public string StoreId { get; set; }
        public int StoreActualQuantity { get; set; } //vua bo cham ?

        public virtual Product Product { get; set; }
        //public virtual SalesDetail SalesDetail { get; set; }
        public virtual Store Store { get; set; }
        //public virtual User User { get; set; }
        //public int UserId { get; set; }
    }
}
