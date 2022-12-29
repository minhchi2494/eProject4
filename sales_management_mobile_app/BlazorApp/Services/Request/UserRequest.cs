using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace BlazorApp.Services.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public string id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must contains from 3 to 20 characters!")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password must contains from 3 to 20 characters!")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Fullname must contains from 8 to 40 characters!")]
        public string fullname { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Phone must contains from 10 or 11 characters!")]
        public string phone { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Address must contains from 8 to 20 characters!")]
        public string address { get; set; }


        [Required(ErrorMessage = "Manager Id is required")]
        public string managerId { get; set; }

        public bool? isActive { get; set; } = false;
        public MultipartFormDataContent file { get; set; }
    }
}
