using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BlazorApp.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }

        [Required]
        public string ProductId { get; set; }

        [Required]
        public int OrderId { get; set; }

        public decimal? Price { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int ActualQuantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}
