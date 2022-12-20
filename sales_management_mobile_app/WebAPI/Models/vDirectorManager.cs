using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Keyless]
    [Table("vDirectorManager")]
    public class vDirectorManager
    {
        public string Id { get; set; }
        public string DirectorName { get; set; }
        public string ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public int ActualKpi { get; set; }
    }
}
