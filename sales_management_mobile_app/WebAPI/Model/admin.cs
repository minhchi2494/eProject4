using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    [Table("admin")]
    public class admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(20, MinimumLength =2, ErrorMessage ="Username must be 2 to 20 characters!")]
        public string username { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Password must be 2 to 20 characters!")]
        public string password { get; set; }

        [StringLength(40, MinimumLength = 2, ErrorMessage = "Fullname must be 2 to 40 characters!")]
        public string fullname { get; set; }

        [StringLength(30, MinimumLength = 2, ErrorMessage = "Email must be 3 to 30 characters!")]
        public string email { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Phone must be 2 to 20 characters!")]
        public string phone { get; set; }
    }
}
