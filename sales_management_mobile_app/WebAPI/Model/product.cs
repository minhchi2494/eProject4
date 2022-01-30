using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    [Table("product")]
    public class product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }

        [StringLength(30)]
        public string name { get; set; }

        public decimal price { get; set; }

        [StringLength(10)]
        public string unit { get; set; }

        public ICollection<image> images { get; set; }
        public ICollection<sales_detail> sales_details { get; set; }
        public ICollection<store_sales_detail> store_sales_details { get; set; }
    }
}
