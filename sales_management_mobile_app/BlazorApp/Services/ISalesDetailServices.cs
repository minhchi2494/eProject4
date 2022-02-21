using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface ISalesDetailServices
    {
        Task<List<SalesDetail>> getSalesDetail(DateTime? fromDate, DateTime? toDate);
    }
}
