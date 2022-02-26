using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema
    ;
namespace WebAPI.Models
{
    [Table("vTargetUser")]
    public class vTargetUser
    {
        [Key]
        public int Id { get; set; }
        public int Targets { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int ActualQuantity { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Fullname { get; set; }
    }
}
