﻿
namespace BlazorCommerce.Client.Services.ProductsService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();

        public async Task GetProducts()
        {
            var result = 
                await _http.GetFromJsonAsync<ServiceResponse<List<ProductModel>>>("api/product");
            if (result != null && result.Data != null) Products = result.Data;
        }
    }
}
