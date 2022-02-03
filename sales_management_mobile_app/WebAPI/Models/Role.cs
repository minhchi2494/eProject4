﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
