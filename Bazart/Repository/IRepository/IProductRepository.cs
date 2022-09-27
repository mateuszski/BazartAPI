using Bazart.API.DTO;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Repository.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();

        ProductDto GetProductById([FromRoute] int id);

        Product GetProductToRemove(int userId);

        int CreateNewProduct(CreateProductDto create);

        void RemoveProduct(int id);

        void UpdateProduct(int id, UpdateProductDto update);

        IEnumerable<ProductDto> GetProductsByUserId([FromRoute] int id);

        IEnumerable<ProductDto> GetLatestProducts();
    }
}