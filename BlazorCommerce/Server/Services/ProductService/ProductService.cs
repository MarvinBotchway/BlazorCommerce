namespace BlazorCommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<List<ProductModel>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<ProductModel>>
            {
                Data = await _context.Products.ToListAsync()
            };

            return response;

            
        }
    }
}
