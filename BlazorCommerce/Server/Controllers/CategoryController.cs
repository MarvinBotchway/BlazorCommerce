using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CategoryController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<CategoryModel>>> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
