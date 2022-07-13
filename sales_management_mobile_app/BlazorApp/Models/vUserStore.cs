using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [Table("vUserStore")]
    public class vUserStore
    {
        public int Id { get; set; }
        public string Salesman { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }
}
