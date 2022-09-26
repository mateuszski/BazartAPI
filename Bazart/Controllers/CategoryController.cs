using Bazart.API.Repository.IRepository;
using Bazart.API.Repository;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            return Ok(categories);
        }
    }
}