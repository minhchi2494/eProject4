using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.AdminModel
{
    public class AddAdmin
    {
        [Required]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Email must contains from 3 to 16 characters!")]
        public string Username { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Email must contains from 8 to 40 characters!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        public string Password { get; set; }
    }
}
