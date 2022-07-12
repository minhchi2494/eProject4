using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorApp.Models
{
    public partial class User
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Username must contains from 2 to 20 characters!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password must contains from 3 to 20 characters!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Fullname must contains from 2 to 40 characters!")]
        public string Fullname { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Phone must contains from 8 to 20 characters!")]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Manager Id is required")]
        public string ManagerId { get; set; }

        public int KpiValue { get; set; } = 0;
        public int ActualKpi { get; set; } = 0;

        public bool? IsActive { get; set; } = true;


        public virtual Manager Manager { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
