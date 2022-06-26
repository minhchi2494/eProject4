﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Target
    {
        public int Id { get; set; }
        public int Targets { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? ActualQuantity { get; set; } 
        public DateTime CreatedOn { get; set; } = DateTime.Now;


        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
