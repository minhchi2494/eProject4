using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class LocationServices : ILocationServices
    {
        private readonly Project4Context _context;

        public LocationServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<Location>> getLocations(Location searchLoc)
        {
            //var result = _context.Locations.ToList();
            //result = result.Where(l => l.IsDelete == false).ToList();
            var result = _context.Locations.Where(l => l.IsActive == true).ToList();
            if (!string.IsNullOrEmpty(searchLoc.District))
            {
                result = result.Where(l => l.District.ToLower().Contains(searchLoc.District.ToLower())).ToList();
            }
            return result;
        }

        public async Task<Location> getLocation(int id)
        {
            var result = _context.Locations.Where(l => l.IsActive == true).SingleOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> createLoc(Location newLoc)
        {
            var loc = _context.Locations.SingleOrDefault(l => l.Id == newLoc.Id);
            if (loc == null)
            {
                _context.Locations.Add(newLoc);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateLoc(Location editLoc)
        {
            var loc = _context.Locations.SingleOrDefault(l => l.Id == editLoc.Id);
            if (loc != null)
            {
                loc.District = editLoc.District;
                loc.Ward = editLoc.Ward;
                loc.IsActive = editLoc.IsActive;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
