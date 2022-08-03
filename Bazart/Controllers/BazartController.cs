using AutoMapper;
using Bazart.DataAccess.Data;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazart.Controllers
{
    [Route("api/bazart")]
    public class BazartController : ControllerBase
    {
        private readonly BazartDbContext _dbContext;
        private readonly IMapper _mapper;
        public BazartController(BazartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        //[Route("api/bazart")]
        //// https://localhost:7120/api/bazart
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
        public ActionResult<IEnumerable<ProductDto>> GetById(int id)
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

        //[HttpPost]
        //public ActionResult CreateProduct([FromBody] CreateProductDto create)
        //{

        //}

    }
}
