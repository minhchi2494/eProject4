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
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }

        public int? LocationId { get; set; }
        [Required]
        public int? RoleId { get; set; }
        [Required]
        public string ManagerId { get; set; }
        public bool? IsActive { get; set; }

        public int TargetId { get; set; }
        public int ActualTarget { get; set; }


        public virtual Location Location { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Role Role { get; set; }
        public virtual Target Target { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
