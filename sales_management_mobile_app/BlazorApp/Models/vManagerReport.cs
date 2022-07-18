using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [Table("vManagerReport")]
    public class vManagerReport
    {
        public string ManagerId { get; set; }
        public string Manager { get; set; }
        public string Store { get; set; }
        public string Product { get; set; }
        public int ActualQuantity { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
