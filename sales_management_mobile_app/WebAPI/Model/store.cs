using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(40)]
        public string name { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        public int longitude { get; set; }

        public int latitude { get; set; }

        public int location_id { get; set; }
        public location location { get; set; }

        public ICollection<user> users { get; set; }

        public ICollection<store_sales_detail> store_sales_details { get; set; }
    }
}
