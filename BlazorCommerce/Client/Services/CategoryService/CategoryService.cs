namespace BlazorCommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();

        public async Task GetCategoriesAsync()
        {
            var response = 
                await _http.GetFromJsonAsync<ServiceResponse<List<CategoryModel>>>("/api/category");
            if (response != null && response.Data != null) Categories = response.Data;
        }
    }
}
