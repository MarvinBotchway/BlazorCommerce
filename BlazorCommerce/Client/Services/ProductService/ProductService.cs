
namespace BlazorCommerce.Client.Services.ProductsService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();

        public async Task GetProductsAsync()
        {
            var result = 
                await _http.GetFromJsonAsync<ServiceResponse<List<ProductModel>>>("api/product");
            if (result != null && result.Data != null) Products = result.Data;
        }

        public async Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<ProductModel>>($"/api/product/{id}");
            if (response != null && response.Data != null) return (response);
            throw new Exception();
        }
    }
}
