﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? LocationId { get; set; }
        public int RoleId { get; set; }
        public string ManagerId { get; set; }
        public bool IsActive { get; set; }

        public virtual Location Location { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Target> Targets { get; set; }

    }
}