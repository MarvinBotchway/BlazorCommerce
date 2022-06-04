namespace BlazorCommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _context;

        public CategoryService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<CategoryModel>>> GetCategoriesAsync()
        {
            var response = new ServiceResponse<List<CategoryModel>>()
            {
                Data = await _context.Categories.ToListAsync()
            };

            return response;
          
        }
    }
}
