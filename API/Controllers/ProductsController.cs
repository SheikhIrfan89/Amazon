using API.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductsController(IProductService reporsitory, IMapper mapper)
        {
            _reporsitory = reporsitory;
            _mapper = mapper;
        }


        [HttpGet("GetProducts")]

        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var productList = await _reporsitory.GetProductsByAsync();

            //return productList.Select(product => new ProductDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Brand = product.Brand.Name,
            //    BrandId = product.BrandId,
            //    Type = product.Types.Name,
            //    TypesId = product.Types.Id
            //}).ToList();


            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(productList));


            //return Ok(productList);

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Product>>> GetProductsByID(Guid id)
        {
            var product = await _reporsitory.GetProductByIdAsync(id);

            if (product == null)
                return BadRequest($"Product with ID {id} not found");

            return Ok(product);

        }


        [HttpPost("AddProduct")]

        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            var products = await _reporsitory.AddProductAsync(product);
            return Ok(products);


        }

        [HttpDelete("Delete Product")]

        public async Task<ActionResult<List<Product>>> DeleteProduct(Product product)
        {
            var prod = await _reporsitory.GetProductByIdAsync(product.Id);

            if (prod == null)
                return BadRequest($"Product with ID {product.Id} not present");

            var products = await _reporsitory.DeleteProductAsync(product);
            return Ok(products);
        }

        [HttpPut("UpdateProduct")]

        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var prod = await _reporsitory.GetProductByIdAsync(product.Id);

            if (prod == null)
                return BadRequest($"Product with ID {product.Id} not present");


            var products = await _reporsitory.UpdateProductAsync(product);
            return Ok(products);
        }



    }
}
