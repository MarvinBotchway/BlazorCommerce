
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
        public string Message { get; set; } = "Loading Products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public event Action ProductsListChanged;

        public async Task GetProductsAsync(string? categoryNameForUrl = null)
        {

            string requestUrl = categoryNameForUrl == null ? "api/product/featured" : $"api/product/category/{categoryNameForUrl}";

            var response =
            await _http.GetFromJsonAsync<ServiceResponse<List<ProductModel>>>(requestUrl);
            if (response != null && response.Data != null) Products = response.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0)
            {
                Message = "No Products found";
            }



            ProductsListChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestionsAsync(string searchText)
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<List<string>>>($"/api/product/searchsuggestions/{searchText}");
            return response.Data;
        }

        public async Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<ProductModel>>($"/api/product/{id}");
            if (response != null && response.Data != null) return (response);
            throw new Exception();
        }

        public async Task SearchProductsAsync(string searchText, int page)
        {
            LastSearchText = searchText;
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<ProductSearchResultDTO>>($"/api/product/search/{searchText}/{page}");

            if (response != null && response.Data != null)
            {
                Products = response.Data.Products;
                CurrentPage = response.Data.CurrentPage;
                PageCount = response.Data.Pages;
            }
                
            
            if (Products.Count == 0)
            {
                Message = "No products found";
            }
              
            ProductsListChanged?.Invoke();
        
        }
    }
}
