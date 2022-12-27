using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebAPI.Models
{
    [Keyless]
    [Table("vKpiPerMonth")]
    public class vKpiPerMonth
    {
        public string Director { get; set; }
        public string Manager { get; set; }
        public string Salesman { get; set; }
        public int Month { get; set; }
        public int KpiValue { get; set; }
    }
}
