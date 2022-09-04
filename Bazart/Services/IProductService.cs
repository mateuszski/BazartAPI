using Bazart.API.DTO;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Services;

public interface IProductService
{
    IEnumerable<ProductDto> GetAllProducts();

    ProductDto GetProductById([FromRoute] int id);

    int CreateNewProduct(CreateProductDto create);

    void RemoveProduct(int id);

    void UpdateProduct(int id, UpdateProductDto update);

    IEnumerable<ProductDto> GetProductsByUserId([FromRoute] int id);

    IEnumerable<ProductDto> GetLatestProducts();
}