using Bazart.DataAccess.Data;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.Controllers
{
    [Route("api/bazart")]
    public class BazartController : ControllerBase
    {
        private readonly BazartDbContext _dbContext;
        public BazartController(BazartDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        //[Route("api/bazart")]
        //// https://localhost:7120/api/bazart
        public ActionResult<IEnumerable<Product>> GetAll([FromQuery]string? like=null)
        {
            var bazart = _dbContext.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(like))
            {
                bazart = bazart.Where(d => d.Description.Contains(like));
            }

            return Ok(bazart.ToList());
        }

        [HttpGet("{id:int}")]
        //[Route("{id:int}")]
        public ActionResult<IEnumerable<Product>> GetById(int id)
        {
            var bazartId = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (bazartId is null)
            {
                return NotFound();
            }

            return Ok(bazartId);
        }

    }
}
