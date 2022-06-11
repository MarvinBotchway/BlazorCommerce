namespace BlazorCommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProductModel>>> GetFeaturedProductsAsync()
        {
            var response = new ServiceResponse<List<ProductModel>>()
            {
                Data = await _context.Products
                .Where(p => p.Featured == true)
                .Include(p => p.Variants)
                .ToListAsync()
            };
            return response;
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

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);

            List<string> result = new List<string>();
            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }
                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase) 
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }

                }
            }

            return new ServiceResponse<List<string>> { Data = result };
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

        public async Task<ServiceResponse<ProductSearchResultDTO>> SearchProductsAsync(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResults);
            var products = await _context.Products
                    .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                    ||
                    p.Description.ToLower().Contains(searchText.ToLower()))
                    .Include(p => p.Variants)
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .ToListAsync();

            var response = new ServiceResponse<ProductSearchResultDTO>()
            {
                Data = new ProductSearchResultDTO
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };
            return response;
        }    
    
        
        private async Task<List<ProductModel>> FindProductsBySearchText(string searchText)
        {
        return await _context.Products
                    .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                    ||
                    p.Description.ToLower().Contains(searchText.ToLower()))
                    .Include(p => p.Variants)
                    .ToListAsync();
        }
        

    }
}
