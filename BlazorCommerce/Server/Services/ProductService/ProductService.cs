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
                Data = await _context.Products
                .Include(p => p.Variants)
                .ToListAsync()
            };

            return response;

            
        }

        public async Task<ServiceResponse<List<ProductModel>>> GetProductsForCategoryAsync(string categoryNameForUrl)
        {
            var response = new ServiceResponse<List<ProductModel>>();
            var products = await _context.Products
                .Where<ProductModel>(p => p.Category.NameForUrl == categoryNameForUrl)
                .Include(p => p.Variants)
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
            var product = await _context.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);

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

        public async Task<ServiceResponse<List<ProductModel>>> SearchProductsAsync(string searchText)
        {
            var response = new ServiceResponse<List<ProductModel>>()
            { 
                Data = await _context.Products
                    .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                    || 
                    p.Description.ToLower().Contains(searchText.ToLower()))
                    .Include(p => p.Variants)
                    .ToListAsync()
            };
            return response;
        }      
        
    }
}
