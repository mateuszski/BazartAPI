using Bazart.API.DTO;
using Bazart.Models;
using Bazart.Services;
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
        public ActionResult<IEnumerable<ProductDto>> GetById([FromRoute] int id)
        {
            var productById = _productService.GetProductById(id);
            return Ok(productById);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] CreateProductDto create)
        {
            var productId = _productService.CreateNewProduct(create);
            return Created($"/api/product{productId}", null);
        }

        [HttpDelete("{id:int}")]
        public ActionResult RemoveProduct([FromRoute] int id)
        {
            _productService.RemoveProduct(id);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto update)
        {
            _productService.UpdateProduct(id, update);

            return Ok();
        }
    }
}