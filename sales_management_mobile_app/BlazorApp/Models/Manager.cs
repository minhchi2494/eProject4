using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Manager
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Fullname { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [Required]
        public string DirectorId { get; set; }


        public int KpiValue { get; set; }
        public int ActualKpi { get; set; }

        public virtual Director Director { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
