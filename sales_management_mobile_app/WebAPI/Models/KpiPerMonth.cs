using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class KpiPerMonth
    {
        public string Id { get; set; }
        public int Value { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public KpiPerMonth(string Id, int Value, int UserId)
        {
            this.Id = Id;
            this.Value = Value;
            this.UserId = UserId;
        }
    }
}
