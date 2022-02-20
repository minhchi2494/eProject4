
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface ILocationServices
    {
        Task<List<Location>> getLocations(Location searchLoc);
        Task<Location> getLocation(int id);
        Task<bool> createLoc(Location newLoc);
        Task<bool> updateLoc(Location editLoc);
    }
}
