

namespace BlazorApp.Models
{
    public class Admin
    {
        public int Id { get; set; }

        public string Username { get; set; }

        //public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public bool IsDeleting { get; set; }
    }
}
