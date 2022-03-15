using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ITargetServices
    {
        Task<List<Target>> getTargets(DateTime? fromDate, DateTime? toDate);
        
        Task<bool> createTarget(Target newTarget);
    }
}
