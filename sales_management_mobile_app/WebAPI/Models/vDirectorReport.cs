using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Keyless]
    [Table("vDirectorReport")]
    public class vDirectorReport
    {
        public string Director { get; set; }
        public string Manager { get; set; }
        public string Store { get; set; }
        public string Product { get; set; }
        public string Unit { get; set; }
        public int ActualQuantity { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
