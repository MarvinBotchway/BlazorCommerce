namespace BlazorCommerce.Client.Services.ProductsService
{
    public interface IProductsService
    {
        public List<ProductModel> Products { get; set; }

        Task GetProducts();
    }
}
