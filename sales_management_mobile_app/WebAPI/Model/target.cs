using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    [Table("target")]
    public class target
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int targets { get; set; }

        public DateTime from_date { get; set; }

        public DateTime to_date { get; set; }

        public int actual_quantity { get; set; }

        public ICollection<sales_detail> sales_details { get; set; }

        public ICollection<user> users { get; set; }
    }
}
