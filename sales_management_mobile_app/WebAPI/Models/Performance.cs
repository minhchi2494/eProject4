using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Performance
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int YTD { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public virtual Target Target { get; set; }
        //ublic virtual ICollection<User> User { get; set; }
    }
}
