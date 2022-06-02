namespace BlazorCommerce.Client.Services.ProductsService
{
    public interface IProductService
    {
        public List<ProductModel> Products { get; set; }

        Task GetProducts();
    }
}
