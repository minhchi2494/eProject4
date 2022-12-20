using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Keyless]
    [Table("vManagerUser")]
    public class vManagerUser
    {
        public string Id { get; set; }
        public string Manager { get; set; }
        public string Salesman { get; set; }
        public string SalesmanId { get; set; }
        public string Phone { get; set; }
        public int ActualKpi { get; set; }
    }
}
