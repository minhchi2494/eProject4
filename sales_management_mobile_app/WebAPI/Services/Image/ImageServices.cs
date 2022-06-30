using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ImageServices : IImageServices
    {
        private readonly Project4Context _context;

        public ImageServices(Project4Context context)
        {
            _context = context;
        }

        //public async Task<List<Image>> getImages()
        //{
        //    return _context.Images.ToList();
        //}
    }
}
