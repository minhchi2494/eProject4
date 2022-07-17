using System;
using System.Collections.Generic;


namespace WebAPI.Models
{
    
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ManagerId { get; set; }
        public int KpiValue { get; set; }
        public int ActualKpi { get; set; }
        public int RoleId { get; set; } = 3;

        public string ConfirmPassword { get; set; }
        public string OldPassword { get; set; }
        public bool IsActive { get; set; }

        public virtual Role Role { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual ICollection<Store> Stores { get; set; }


        
    }
}