using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [Table("vManagerUser")]
    public class vManagerUser
    {
        public string Id { get; set; }
        public string Manager { get; set; }
        public string Salesman { get; set; }
        public int SalesmanId { get; set; }
    }
}
