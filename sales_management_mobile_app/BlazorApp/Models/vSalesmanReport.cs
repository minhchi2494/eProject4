using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [Table("vSalesmanReport")]
    public class vSalesmanReport
    {
        public string SalesmanId { get; set; }
        public string Salesman { get; set; }
        public string Store { get; set; }
        public string Product { get; set; }
        public int ActualQuantity { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
