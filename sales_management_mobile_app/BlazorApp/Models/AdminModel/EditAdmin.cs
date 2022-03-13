using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.AdminModel
{
    public class EditAdmin
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Username { get; set; }


        [Required]
        public string Phone { get; set; }


        [MinLength(3, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        public string Password { get; set; }

        public EditAdmin() { }

        public EditAdmin(Admin admin)
        {
            Fullname = admin.Fullname;
            Username = admin.Username;
            Phone = admin.Phone;
            //Password = admin.Password;
        }
    }
}
