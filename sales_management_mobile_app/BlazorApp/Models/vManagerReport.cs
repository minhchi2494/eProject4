using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [Table("vManagerReport")]
    public class vManagerReport
    {
        public string Manager { get; set; }
        public string Salesman { get; set; }
        public string Store { get; set; }
        public string Product { get; set; }
        public string Unit { get; set; }
        public int ActualQuantity { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
