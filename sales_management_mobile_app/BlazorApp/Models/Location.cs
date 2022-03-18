using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Location
    {
        public Location()
        {
            Managers = new HashSet<Manager>();
            Stores = new HashSet<Store>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Ward { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
