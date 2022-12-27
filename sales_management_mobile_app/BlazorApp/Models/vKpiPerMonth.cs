
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [Table("vKpiPerMonth")]
    public class vKpiPerMonth
    {
        public string Director { get; set; }
        public string Manager { get; set; }
        public string Salesman { get; set; }
        public int Month { get; set; }
        public int KpiValue { get; set; }
    }
}
