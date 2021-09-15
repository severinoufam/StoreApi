using StoreApi.Models;
using StoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productsService;

        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        //GET List All/Products
        [HttpGet]
        public ActionResult<List<Product>> Get() => _productsService.Get();

        //GET Id/Product
        [HttpGet("{id:length(24)}", Name = "GetProducts")]
        public ActionResult<Product> Get(string id)
        {
            var product = _productsService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        //POST Create/Product
        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _productsService.Create(product);

            return CreatedAtRoute("GetProduts", new { id = product.Id.ToString() }, product);
        }

        //PUT Update/Product
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Product productIn)
        {
            var product = _productsService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productsService.Update(id, productIn);

            return NoContent();
        }

        //DELETE remove/Product
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var product = _productsService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productsService.Remove(product.Id);

            return NoContent();
        }
    }
}