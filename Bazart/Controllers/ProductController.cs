using AutoMapper;
using Bazart.DataAccess.Data;
using Bazart.Models;
using Bazart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazart.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        //[Route("api/product")]
        //// https://localhost:7120/api/product
        public ActionResult<IEnumerable<ProductDto>> GetAll([FromQuery]string? like=null)
        {
            var products = _productService.GetAllProducts();
            if (!string.IsNullOrWhiteSpace(like))
            {
                products = products.Where(d => d.Description.Contains(like));
            }

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        //[Route("{id:int}")]
        public ActionResult<IEnumerable<ProductDto>> GetById([FromRoute]int id)
        {
            var productById = _productService.GetProductById(id);
            if (productById is null)
            {
                return NotFound();
            }

            return Ok(productById);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] CreateProductDto create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productId  = _productService.CreateNewProduct(create);

            return Created($"/api/product{productId}",null);
        }

        [HttpDelete("{id:int}")]
        public ActionResult RemoveProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            bool isRemoveProduct = _productService.RemoveProduct(id);
            if (!isRemoveProduct)
            {
                return NotFound();
            }
            
            return NoContent();
        }

    }
}
