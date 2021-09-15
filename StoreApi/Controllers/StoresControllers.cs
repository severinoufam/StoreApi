using StoreApi.Models;
using StoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly StoresService _storesService;

        public StoresController(StoresService storesService)
        {
            _storesService = storesService;
        }

        //GET List All/Stores
        [HttpGet]
        public ActionResult<List<Store>> Get() => _storesService.Get();

        //GET Id/Store
        [HttpGet("{id:length(24)}", Name = "GetStore")]
        public ActionResult<Store> Get(string id)
        {
            var store = _storesService.Get(id);

            if (store == null)
            {
                return NotFound();
            }

            return store;
        }

        //POST Create/Store
        [HttpPost]
        public ActionResult<Store> Create(Store store)
        {
            _storesService.Create(store);

            return CreatedAtRoute("GetStore", new { id = store.Id.ToString() }, store);
        }

        //PUT Update/Store
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Store storeIn)
        {
            var store = _storesService.Get(id);

            if (store == null)
            {
                return NotFound();
            }

            _storesService.Update(id, storeIn);

            return NoContent();
        }

        //DELETE remove/Store
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var store = _storesService.Get(id);

            if (store == null)
            {
                return NotFound();
            }

            _storesService.Remove(store.Id);

            return NoContent();
        }
    }
}