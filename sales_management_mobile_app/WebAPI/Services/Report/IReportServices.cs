using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IReportServices
    {
        Task<List<Report>> getReports(DateTime? fromDate, DateTime? toDate);
    }
}
