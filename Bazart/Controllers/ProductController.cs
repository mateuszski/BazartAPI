using System.Security.Claims;
using Bazart.API.DTO;
using Bazart.API.Services;
using Bazart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll([FromQuery] string? like = null)
        {
            var products = _productService.GetAllProducts();
            if (!string.IsNullOrWhiteSpace(like))
            {
                products = products.Where(d => d.Description.Contains(like));
            }

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public ActionResult<IEnumerable<ProductDto>> GetById([FromRoute] int id)
        {
            var productById = _productService.GetProductById(id);
            return Ok(productById);
        }

        [HttpGet("user/{id:int}")]
        [Authorize]
        public ActionResult<IEnumerable<ProductDto>> GetProductsByUserId([FromRoute] int id)
        {
            Console.WriteLine("test");
            var productsByUserId = _productService.GetProductsByUserId(id);
            return Ok(productsByUserId);
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateProduct([FromBody] CreateProductDto create)
        {
            var productId = _productService.CreateNewProduct(create);
            return Created($"/api/product{productId}", null);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public ActionResult RemoveProduct([FromRoute] int id)
        {
            //var userClaim = User.Claims;
            var userClaims = User.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            }).FirstOrDefault(c => c.Type == "nameidentifier");

            Console.WriteLine(userClaims);

            //foreach (var item in userClaims)
            //{
            //}
            _productService.RemoveProduct(id);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public ActionResult UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto update)
        {
            _productService.UpdateProduct(id, update);

            return Ok();
        }

        [HttpGet("latest")]
        public ActionResult<IEnumerable<ProductDto>> LatestProducts()
        {
            var latestProducts = _productService.GetLatestProducts();
            return Ok(latestProducts);
        }
    }
}