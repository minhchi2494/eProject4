using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace BlazorApp.Models
{
    public class Store
    {
        public Store()
        {
            StoreSalesDetails = new HashSet<StoreSalesDetail>();
            Users = new HashSet<User>();
        }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public decimal? Longitude { get; set; }
        [Required]
        public decimal? Latitude { get; set; }
        [Required]
        public int? LocationId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<StoreSalesDetail> StoreSalesDetails { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
