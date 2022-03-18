using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [Table("vSalesDetailTargetUser")]
    public class vSalesDetailTargetUser
    {
        //public int Id { get; set; }
        public int? SalesActualQuantity { get; set; }
        public int? TargetId { get; set; }
        public string ProductId { get; set; }
        public decimal? Price { get; set; }
        public DateTime Date { get; set; }

        public int? Targets { get; set; }

        public string Fullname { get; set; }
    }
}
