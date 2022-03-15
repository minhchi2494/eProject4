using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema
    ;
namespace WebAPI.Models
{
    [Table("vTargetUserManager")]
    public class vTargetUserManager
    {
        [Key]
        public int Id { get; set; }
        public int Targets { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int ActualQuantity { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Salesman { get; set; }
        public string Manager { get; set; }
    }
}
