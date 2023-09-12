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

        public async Task<ActionResult<ProductType>> GetProductTypeByID(Guid id)
        {
            var productType = await _repository.GetProductTypeByIdAsync(id);

            if (productType == null)
                return BadRequest($"Brands with ID {id} not Found");

            return Ok(productType);

        }

        [HttpPost("AddProductTypes")]

        public async Task<ActionResult<ProductType>> AddProductTypes(ProductType productType)
        {
            var prodtypes = await _repository.AddProductTypeAsync(productType);
            return Ok(prodtypes);

        }

        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<ProductType>> DeleteProductType(ProductType productType)
        {
            var prodType = await _repository.GetProductTypeByIdAsync(productType.Id);
            if (prodType == null)
                return BadRequest($"Product type with {productType.Id} does not exists!");

            var typeOfProducts = await  _repository.DeleteProductTypeAsync(productType);
            return Ok(typeOfProducts);
        }

        [HttpPut("UpdateProduct")]

        public async Task<ActionResult<ProductType>> UpdateProductType(ProductType productType)
        {
            var prodType = await _repository.GetProductTypeByIdAsync(productType.Id);

            if (prodType == null)
                return BadRequest($"Product type with {productType.Id} not present");

            var typeOfProducts=  await _repository.UpdateProductTypeAsync(productType);
            return Ok(typeOfProducts);

        }
    }
}
