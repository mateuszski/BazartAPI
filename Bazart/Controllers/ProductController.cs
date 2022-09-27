using System.Security.Claims;
using Bazart.API.DTO;
using Bazart.API.Repository.IRepository;
using Bazart.API.Repository;
using Bazart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll([FromQuery] string? like = null)
        {
            var products = _productRepository.GetAllProducts();
            if (!string.IsNullOrWhiteSpace(like))
            {
                products = products.Where(d => d.Description.Contains(like));
            }

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<ProductDto>> GetById([FromRoute] int id)
        {
            var productById = _productRepository.GetProductById(id);
            return Ok(productById);
        }

        [HttpGet("user/{id:int}")]
        [Authorize]
        public ActionResult<IEnumerable<ProductDto>> GetProductsByUserId([FromRoute] int id)
        {
            Console.WriteLine("test");
            var productsByUserId = _productRepository.GetProductsByUserId(id);
            return Ok(productsByUserId);
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateProduct([FromBody] CreateProductDto create)
        {
            var productId = _productRepository.CreateNewProduct(create);
            return Created($"/api/product{productId}", null);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public ActionResult RemoveProduct([FromRoute] int id)
        {
            //var userClaim = User.Claims.FirstOrDefault(c => c.Type == "nameidentifier");
            //var userClaims = User.Claims.Select(c => new
            //{
            //    Type = c.Type,
            //    Value = c.Value

            //foreach (var item in userClaims)
            //{
            //}
            _productRepository.RemoveProduct(id);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public ActionResult UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto update)
        {
            _productRepository.UpdateProduct(id, update);

            return Ok();
        }

        [HttpGet("latest")]
        public ActionResult<IEnumerable<ProductDto>> LatestProducts()
        {
            var latestProducts = _productRepository.GetLatestProducts();
            return Ok(latestProducts);
        }
    }
}