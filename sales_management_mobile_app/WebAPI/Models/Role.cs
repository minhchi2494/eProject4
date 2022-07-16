using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
