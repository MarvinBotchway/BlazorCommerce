namespace BlazorCommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<ProductModel>>> GetProductsForCategoryAsync(string categoryNameForUrl);
        Task<ServiceResponse<List<ProductModel>>> GetProductsAsync();
        Task<ServiceResponse<ProductSearchResultDTO>> SearchProductsAsync(string searchText, int page);

        Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
        Task<ServiceResponse<List<ProductModel>>> GetFeaturedProductsAsync();


    }
}
