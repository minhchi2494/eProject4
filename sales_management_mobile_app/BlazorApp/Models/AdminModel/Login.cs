using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.AdminModel
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
