
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
        
        public event Action ProductsListChanged;

        public async Task GetProductsAsync(string? categoryNameForUrl = null)
        {

            string requestUrl = categoryNameForUrl == null ? "api/product" : $"api/product/category/{categoryNameForUrl}";

            var response =
            await _http.GetFromJsonAsync<ServiceResponse<List<ProductModel>>>(requestUrl);
            if (response != null && response.Data != null) Products = response.Data;

            ProductsListChanged.Invoke();
        }

        public async Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<ProductModel>>($"/api/product/{id}");
            if (response != null && response.Data != null) return (response);
            throw new Exception();
        }
    }
}
