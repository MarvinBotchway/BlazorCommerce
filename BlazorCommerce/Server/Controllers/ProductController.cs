
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> GetProductsAsync()
        {
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProductModel>>> GetSingleProductAsync(int? id)
        {
            var response = await _productService.GetSingleProductAsync(id);
            return Ok(response);
        }

        [HttpGet("Category/{categoryNameForUrl}")]
        public async Task<ActionResult<ServiceResponse<ProductModel>>> GetProductsForCategoryAsync(string categoryNameForUrl)
        {
            var response = await _productService.GetProductsForCategoryAsync(categoryNameForUrl);
            return Ok(response);
        }

        [HttpGet("Search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResultDTO>>> SearchProductsAsync(string searchText, int page = 1)
        {
            var response = await _productService.SearchProductsAsync(searchText, page);
            return Ok(response);
        }

        [HttpGet("SearchSuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<ProductModel>>> GetProductSearchSuggestions(string searchText)
        {
            var response = await _productService.GetProductSearchSuggestions(searchText);
            return Ok(response);
        }

        [HttpGet("Featured")]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> GetFeaturedProductsAsync()
        {
            var result = await _productService.GetFeaturedProductsAsync();
            return Ok(result);
        }
    }
}
