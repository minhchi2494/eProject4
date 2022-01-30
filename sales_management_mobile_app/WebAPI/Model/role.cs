using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    [Table("role")]
    public class role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(20)]
        public string title { get; set; }
        public ICollection<user> users { get; set; }
    }
}
