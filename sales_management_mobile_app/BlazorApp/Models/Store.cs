using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace BlazorApp.Models
{
    public class Store
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual User Users { get; set; }

    }
}
