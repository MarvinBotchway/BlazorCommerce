
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }



    }
}
