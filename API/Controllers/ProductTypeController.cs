using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypesService _repository;

        public ProductTypeController(IProductTypesService repository)
        {
            _repository = repository;
        }

        [HttpGet("GetProductTypes")]

        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var productType = await _repository.GetProductTypeByAsync();
            return Ok(productType);

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ProductType>> GetProductBrandByID(Guid id)
        {
            var productType = await _repository.GetProductTypeByIdAsync(id);

            if (productType == null)
                return BadRequest($"Brands with ID {id} not Found");

            return Ok(productType);

        }
    }
}
