using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface ITargetServices
    {
        Task<List<Target>> getTargets(DateTime? fromDate, DateTime? toDate);

    }


}
