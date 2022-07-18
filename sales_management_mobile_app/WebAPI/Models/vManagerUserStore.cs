using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Keyless]
    [Table("vManagerUserStore")]
    public class vManagerUserStore
    {
        public string ManagerId { get; set; }
        public string Store { get; set; }
    }
}
