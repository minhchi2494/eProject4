using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class KpiPerMonth
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public KpiPerMonth(int Id, decimal Value, int UserId)
        {
            this.Id = Id;
            this.Value = Value;
            this.UserId = UserId;
        }
    }
}
