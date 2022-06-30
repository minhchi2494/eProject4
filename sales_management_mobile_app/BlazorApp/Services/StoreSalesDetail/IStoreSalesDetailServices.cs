using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IStoreSalesDetailServices
    {
        Task<List<OrderDetail>> getStoreSalesDetails(DateTime? fromDate, DateTime? toDate);
    }
}
