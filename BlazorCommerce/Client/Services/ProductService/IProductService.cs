namespace BlazorCommerce.Client.Services.ProductsService
{
    public interface IProductService
    {
        event Action ProductsListChanged;
        public List<ProductModel> Products { get; set; }
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }
        Task GetProductsAsync(string? categoryNameForUrl = null);
        Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id);
        Task SearchProductsAsync(string searchText, int page);
        Task<List<string>> GetProductSearchSuggestionsAsync(string searchText);
    }
}
