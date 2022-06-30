using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorApp.Models
{
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Fullname { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [Required]
        public string ManagerId { get; set; }

        public int KpiYear { get; set; }
        public int KpiValue { get; set; }
        public int ActualKpi { get; set; }

        public bool? IsActive { get; set; }


        public virtual Manager Manager { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
