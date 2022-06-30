using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageServices _services;

        public ImageController(IImageServices services)
        {
            _services = services;
        }

        //[HttpGet]
        //public Task<List<Image>> getImages()
        //{
        //    return _services.getImages();
        //}
    }
}
