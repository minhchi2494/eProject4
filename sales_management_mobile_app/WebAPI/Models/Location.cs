using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
