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
    public class StoreSalesDetailStoreUserController : ControllerBase
    {
        private readonly IStoreSalesDetailStoreUserServices _services;

        public StoreSalesDetailStoreUserController(IStoreSalesDetailStoreUserServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<vStoreSalesDetailStoreUser>> getStoreSalesDetailStoreUsers(DateTime? fromDate, DateTime? toDate)
        {
            return _services.getStoreSalesDetailStoreUsers(fromDate, toDate);
        }
    }
}
