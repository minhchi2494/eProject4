using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Store
    {
        public Store()
        {
            StoreSalesDetails = new HashSet<StoreSalesDetail>();
            Users = new HashSet<User>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? Longitude { get; set; }
        public int? Latitude { get; set; }
        public int? LocationId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<StoreSalesDetail> StoreSalesDetails { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
