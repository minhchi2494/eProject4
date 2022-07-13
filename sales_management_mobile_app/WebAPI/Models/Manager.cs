﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public class Manager
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string DirectorId { get; set; }
        public int KpiValue { get; set; }
        public int ActualKpi { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Director Director { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
