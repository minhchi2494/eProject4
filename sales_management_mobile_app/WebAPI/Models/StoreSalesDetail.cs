using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class StoreSalesDetail
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public DateTime? Date { get; set; }
        public string StoreId { get; set; }
        public int? StoreActualQuantity { get; set; }

        public virtual Product Product { get; set; }
        //public virtual SalesDetail SalesDetail { get; set; }
        public virtual Store Store { get; set; }
        //create relationship
        public int UserId { get; set; }
        public virtual User Users { get; set; }
    }
}
