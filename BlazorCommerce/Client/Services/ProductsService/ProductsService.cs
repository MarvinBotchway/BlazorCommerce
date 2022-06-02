
namespace BlazorCommerce.Client.Services.ProductsService
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _http;

        public ProductsService(HttpClient http)
        {
            _http = http;
        }
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();

        public async Task GetProducts()
        {
            var result = 
                await _http.GetFromJsonAsync<ServiceResponse<List<ProductModel>>>("api/products");
            if (result != null && result.Data != null) Products = result.Data;
        }
    }
}
