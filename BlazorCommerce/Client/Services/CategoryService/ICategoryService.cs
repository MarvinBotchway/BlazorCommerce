namespace BlazorCommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<CategoryModel> Categories { get; set; }
        Task GetCategoriesAsync();
    }
}
