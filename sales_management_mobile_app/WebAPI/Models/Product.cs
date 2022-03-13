using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            ImagesNavigation = new HashSet<Image>();
            SalesDetails = new HashSet<SalesDetail>();
            StoreSalesDetails = new HashSet<StoreSalesDetail>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Unit { get; set; }
        public string Images { get; set; }

        //[NotMapped]
        //public IFormFile ImageFiles { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<Image> ImagesNavigation { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
        public virtual ICollection<StoreSalesDetail> StoreSalesDetails { get; set; }
    }
}
