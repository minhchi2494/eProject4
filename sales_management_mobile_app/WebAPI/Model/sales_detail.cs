using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    [Table("sales_detail")]
    public class sales_detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int sales_actual_quantity { get; set; }

        public decimal price { get; set; }

        public DateTime date { get; set; }

        public int target_id { get; set; }
        public target target { get; set; }

        [StringLength(5)]
        public string product_id { get; set; }
        public product product { get; set; }

        public ICollection<store_sales_detail> store_sales_details { get; set; }

    }
}
