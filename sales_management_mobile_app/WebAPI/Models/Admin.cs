using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
#nullable disable

namespace WebAPI.Models
{
    public class Admin
    {
        public int Id { get; set; }

        //[Required]
        public string Username { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[JsonIgnore]
        //  public string Password { get; set; }

        public byte[] PasswordSalt { get; set; }
        //public string PasswordSalt { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string PasswordHash { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
