using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IProductBrandService _repository;

        public ProductBrandsController(IProductBrandService repository)
        {
            _repository = repository;
        }

        [HttpGet("GetBrands")]

        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var brandList = await _repository.GetProductBrandsByAsync();
            return Ok(brandList);

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ProductBrand>> GetProductBrandByID(Guid id)
        {
            var brands = await _repository.GetProductBrandByIdAsync(id);

            if (brands == null)
                return BadRequest($"Brands with ID {id} not Found");

            return Ok(brands);
                 
        }
    }
}
