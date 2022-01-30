using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    [Table("manager")]
    public class manager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(40)]
        public string fullname { get; set; }

        public int staff_quantity { get; set; }

        public int location_id { get; set; }

        public location location { get; set; }

        public ICollection<user> users { get; set; }
    }
}
