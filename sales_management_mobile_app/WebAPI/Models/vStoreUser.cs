using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Keyless]
    [Table("vStoreUser")]
    public class vStoreUser
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Name { get; set; }
    }
}
