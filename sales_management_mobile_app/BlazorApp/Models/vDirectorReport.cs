using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [Table("vDirectorReport")]
    public class vDirectorReport
    {
        public string DirectorId { get; set; }
        public string Director { get; set; }
        public string Store { get; set; }
        public string Product { get; set; }
        public int ActualQuantity { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
