using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Manager
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public int? LocationId { get; set; }
        [Required]
        public int? StaffQuantity { get; set; }

        public int TargetId { get; set; }
        public int ActualTarget { get; set; }

        public virtual Location Location { get; set; }
        public virtual Target Target { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
