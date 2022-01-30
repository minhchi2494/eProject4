using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    [Table("store_sales_detail")]
    public class store_sales_detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int quantity_commit { get; set; }

        public decimal price { get; set; }

        public DateTime date { get; set; }

        public int store_actual_quantity { get; set; }

        public int sales_detail_id { get; set; }
        public sales_detail sales_detail { get; set; }

        [StringLength(5)]
        public string product_id { get; set; }
        public product product { get; set; }

        public string store_id { get; set; }
        public store store { get; set; }

    }
}
