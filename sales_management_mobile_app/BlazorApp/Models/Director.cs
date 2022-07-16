using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Director
    {
        [Required(ErrorMessage ="Id is required")]
        [StringLength(5, MinimumLength =2, ErrorMessage ="Id must contains from 2 to 5 characters!")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Username must contains from 2 to 20 characters!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password must contains from 3 to 20 characters!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }

        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Fullname must contains from 2 to 40 characters!")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Email must contains from 8 to 40 characters!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Phone must contains from 8 to 20 characters!")]
        public string Phone { get; set; }

        public string Address { get; set; }
        public int KpiValue { get; set; } = 0;
        public int ActualKpi { get; set; } = 0;

        public int RoleId { get; set; } = 1;

        public virtual ICollection<Manager> Managers { get; set; }
    }
}
