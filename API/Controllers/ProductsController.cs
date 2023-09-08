using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _reporsitory;

        public ProductsController(IProductService reporsitory)
        {
            _reporsitory = reporsitory;
        }


        [HttpGet("GetProducts")]

        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var productList = await _reporsitory.GetProductsByAsync();

            return Ok(productList);

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Product>>> GetProducts(Guid id)
        {
            var product = await _reporsitory.GetProductByIdAsync(id);

            if (product == null)
                return BadRequest($"Product with ID {id} not found");
            
            return Ok(product);

        }

    }
}
