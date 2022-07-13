using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IReportServices
    {
        Task<List<Report>> getReports(DateTime? fromDate, DateTime? toDate);
    }
}
