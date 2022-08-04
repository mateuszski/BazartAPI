using Bazart.API.DTO;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.Services;

public interface IProductService
{
    IEnumerable<ProductDto> GetAllProducts([FromQuery] string? like = null);
    ProductDto GetProductById([FromRoute]int id);
    int CreateNewProduct(CreateProductDto create);
    bool RemoveProduct(int id);
    bool UpdateProduct(int id, UpdateProductDto update);
}