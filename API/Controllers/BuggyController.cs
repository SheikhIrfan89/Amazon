using API.Errors;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("NotFound")]
        public ActionResult GetNotFoundRequest() {
            
            var product = _context.Products.Find(Guid.NewGuid());

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok(product);     
                    
                         

        }


        [HttpGet("ServerError")]
        public ActionResult GetServerError()
        {

            var product = _context.Products.Find(Guid.NewGuid());

            string name = product.ToString();
            
            return Ok();

        }

        [HttpGet("BadRequest")]

        public ActionResult GetBadRequest() 
        {
            return BadRequest(new ApiResponse(400));
        }


    }
}
