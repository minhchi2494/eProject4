using Microsoft.AspNetCore.Http;
using System;

namespace WebAPI.Requests
{
    public class UserRequest
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string managerId { get; set; }
        public bool isActive { get; set; } = false;
        public IFormFile file { get; set; }

    }
}
