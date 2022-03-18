using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public class Manager
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public int LocationId { get; set; }
        public int StaffQuantity { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
