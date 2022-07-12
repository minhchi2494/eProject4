using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [Table("vDirectorManager")]
    public class vDirectorManager
    {
        public string Id { get; set; }
        public string DirectorName { get; set; }
        public string ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
}
