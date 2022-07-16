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
        [Required(ErrorMessage = "Id is required")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Id must contains from 2 to 5 characters!")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Store Name is required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Store Name must contains from 2 to 40 characters!")]
        public string Name { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Phone must contains from 8 to 20 characters!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Salesman is required")]
        public int UserId { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<Order> Orders { get; set; }
        public virtual User Users { get; set; }

    }
}
