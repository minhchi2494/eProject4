using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Keyless]
    [Table("Report")]
    public class Report
    {
        public int OrderId { get; set; }
        public string Salesman { get; set; }
        public string StoreName { get; set; }
        public string ProductName { get; set; }
        public int ActualQuantity { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
