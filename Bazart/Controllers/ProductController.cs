using AutoMapper;
using Bazart.DataAccess.Data;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazart.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly BazartDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProductController(BazartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        //[Route("api/product")]
        //// https://localhost:7120/api/product
        public ActionResult<IEnumerable<ProductDto>> GetAll([FromQuery]string? like=null)
        {
            var products = _dbContext
                .Products
                .Include(p => p.Categories)
                .ToList()
                .AsQueryable();
                
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            if (!string.IsNullOrWhiteSpace(like))
            {
                products = products.Where(d => d.Description.Contains(like));
            }

            return Ok(productsDto);
        }

        [HttpGet("{id:int}")]
        //[Route("{id:int}")]
        public ActionResult<IEnumerable<ProductDto>> GetById([FromRoute]int id)
        {
            var productsId = _dbContext
                .Products
                .Include(p => p.Categories)
                .FirstOrDefault(p => p.Id == id);
            if (productsId is null)
            {
                return NotFound();
            }

            var productsIdDto = _mapper.Map<ProductDto>(productsId);
            return Ok(productsIdDto);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] CreateProductDto create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = _mapper.Map<Product>(create);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return Created($"/api/product{product.Id}",null);
        }

    }
}
