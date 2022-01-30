using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    [Table("user")]
    public class user
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(20)]
        public string password { get; set; }

        [StringLength (40)]
        public string fullname { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        public int target_id { get; set; }
        public target targets { get; set; }

        public int location_id { get; set; }
        public location location { get; set; }

        public int role_id { get; set; }
        public role role { get; set; }

        public string store_id { get; set; }
        public store store { get; set; }

        public int manager_id { get; set; }
        public manager  manager { get; set; }

    }
}
