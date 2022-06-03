﻿namespace BlazorCommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<ProductModel>>> GetProductsAsync();
        Task<ServiceResponse<ProductModel>> GetSingleProductAsync(int? id);
    }
}