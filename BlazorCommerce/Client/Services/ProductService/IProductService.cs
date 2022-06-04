namespace BlazorCommerce.Client.Services.ProductsService
{
    public interface IProductService
    {
        event Action ProductsListChanged;
        public List<ProductModel> Products { get; set; }

        Task GetProductsAsync(string? categoryNameForUrl);
        Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id);
    }
}
