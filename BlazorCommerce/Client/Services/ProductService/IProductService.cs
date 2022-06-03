namespace BlazorCommerce.Client.Services.ProductsService
{
    public interface IProductService
    {
        public List<ProductModel> Products { get; set; }

        Task GetProductsAsync();
        Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id);
    }
}
