using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Product
    {
        //public Product()
        //{
        //    ImagesNavigation = new HashSet<Image>();
        //    SalesDetails = new HashSet<SalesDetail>();
        //    StoreSalesDetails = new HashSet<StoreSalesDetail>();
        //}
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Unit { get; set; }
        public string Images { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Image> ImagesNavigation { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
        public virtual ICollection<StoreSalesDetail> StoreSalesDetails { get; set; }
    }
}
