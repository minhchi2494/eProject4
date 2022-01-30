using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    [Table("report")]
    public class report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(80, MinimumLength = 2, ErrorMessage = "Description must be 2 to 80 characters!")]
        public string description { get; set; }

        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }
    }
}
