namespace BlazorCommerce.Client.Services.ProductsService
{
    public interface IProductService
    {
        event Action ProductsListChanged;
        public List<ProductModel> Products { get; set; }

        string Message { get; set; }
        Task GetProductsAsync(string? categoryNameForUrl = null);
        Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id);
        Task SearchProductsAsync(string searchText);
        Task<List<string>> GetProductSearchSuggestionsAsync(string searchText);
    }
}
