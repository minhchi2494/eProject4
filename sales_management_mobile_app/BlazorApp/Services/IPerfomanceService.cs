
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IPerformanceService
    {
        Task<List<Performance>> getAll();
    
    }
}
