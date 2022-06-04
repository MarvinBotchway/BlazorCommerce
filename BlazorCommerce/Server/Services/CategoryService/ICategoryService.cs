namespace BlazorCommerce.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoryModel>>> GetCategoriesAsync();
    }
}
