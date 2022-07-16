using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Product
    {
        [Required(ErrorMessage = "Id is required")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Id must contains from 2 to 5 characters!")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Product Name must contains from 2 to 30 characters!")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Images is required")]
        public string Images { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; } = true;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
