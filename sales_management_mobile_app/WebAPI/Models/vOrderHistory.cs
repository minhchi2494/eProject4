using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Keyless]
    [Table("vOrderHistory")]
    public class vOrderHistory
    {
        public string DirectorId { get; set; }
        public string ManagerId { get; set; }
        public int SalesmanId { get; set; }
        public int OrderId { get; set; }
        public string Director { get; set; }
        public string Manager { get; set; }
        public string Salesman { get; set; }
        public string Store { get; set; }
        public int ActualQuantity { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
