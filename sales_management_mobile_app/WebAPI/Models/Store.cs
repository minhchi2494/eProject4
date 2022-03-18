using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace WebAPI.Models
{
    public class Store
    {
        //public Store()
        //{
        //    StoreSalesDetails = new HashSet<StoreSalesDetail>();
        //   // Users = new HashSet<User>();
        //}
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? LocationId { get; set; }
        public bool? IsActive { get; set; }
        public int UserId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<StoreSalesDetail> StoreSalesDetails { get; set; }
        public virtual User Users { get; set; }
        //public string CurrentUserId { get; set; }
    }
}
