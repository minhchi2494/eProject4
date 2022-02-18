using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
