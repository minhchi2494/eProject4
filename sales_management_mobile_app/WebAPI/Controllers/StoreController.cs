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
    public class StoreController : ControllerBase
    {
        private readonly IStoreServices _services;

        public StoreController(IStoreServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public Task<Store> getStore(string id)
        {
            return _services.getStore(id);
        }

        [Route("/store-list")]
        [HttpGet]
        public Task<List<Store>> getStoreList()
        {
            return _services.getList();
        }

        [HttpGet]
        public Task<List<Store>> getStores(Store searchStore)
        {
            return _services.getStores(searchStore);
        }

        [HttpPost]
        public Task<bool> createStore([FromQuery] Store newStore)
        {
            return _services.createStore(newStore);
        }

        [HttpPut]
        public Task<bool> updateStore([FromQuery] Store editStore)
        {
            return _services.updateStore(editStore);
        }
    }

}
