namespace BlazorCommerce.Client.Services.ProductsService
{
    public interface IProductService
    {
        public List<ProductModel> Products { get; set; }
        public List<ProductModel> ProductsForCategory { get; set; }

       
        Task GetProductsForCategoryAsync(int? categoryId);
        Task GetProductsAsync();
        Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id);
    }
}
