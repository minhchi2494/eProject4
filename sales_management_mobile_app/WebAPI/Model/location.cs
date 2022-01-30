using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    [Table("location")]
    public class location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(20)]
        public string district { get; set; }

        [StringLength(20)]
        public string ward { get; set; }

        public ICollection<manager> managers { get; set; }
        public ICollection<user> users { get; set; }
        public ICollection<store> stores { get; set; }
    }
}
