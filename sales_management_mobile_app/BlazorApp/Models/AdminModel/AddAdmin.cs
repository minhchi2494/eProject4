using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.AdminModel
{
    public class AddAdmin
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        public string Password { get; set; }
    }
}
