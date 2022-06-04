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
            var response = new ServiceResponse<List<ProductModel>>()
            {
                Data = await _context.Products.ToListAsync()
            };

            return response;

            
        }

        public async Task<ServiceResponse<List<ProductModel>>> GetProductsByCategoryAsync(int? categoryId)
        {
            var response = new ServiceResponse<List<ProductModel>>();
            var products = await _context.Products
                .Where<ProductModel>(p => p.CategoryId == categoryId)
                .ToListAsync();
                

            if(products == null)
            {
                response.Success = false;
                response.Message = "Sorry, there are no products in this category";
            }
            else
            {
                response.Data = products;
            }

            return response;
        }

        public async Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id)
        {
            var response = new ServiceResponse<ProductModel>();
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, this product does not exit.";
            }
            else
            {
                response.Data = product;
            }

            return response;
        }
    }
}
