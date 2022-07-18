using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class KpiPerMonth
    {
        public int Id { get; set; }

        public int LastMonth { get; set; }
        public int Value { get; set; }
        public string UserName { get; set; }

        public KpiPerMonth(int LastMonth, int Value, string UserName)
        {
            this.LastMonth = LastMonth;
            this.Value = Value;
            this.UserName = UserName;
        }
    }
}
