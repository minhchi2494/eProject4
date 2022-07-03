using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Product
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Images { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
