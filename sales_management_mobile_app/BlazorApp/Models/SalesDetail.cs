using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorApp.Models
{
    public partial class SalesDetail
    {
        public SalesDetail()
        {
            StoreSalesDetails = new HashSet<StoreSalesDetail>();
        }

        public int Id { get; set; }
        public int? SalesActualQuantity { get; set; }
        public int? TargetId { get; set; }
        public string ProductId { get; set; }
       // public decimal? Price { get; set; }
        public DateTime Date { get; set; }

        public virtual Product Product { get; set; }
        public virtual Target Target { get; set; }
        public virtual ICollection<StoreSalesDetail> StoreSalesDetails { get; set; }

        //create relationship
        public int UserId { get; set; }
        public virtual ICollection<User> Users { get; set; }




    }
}
