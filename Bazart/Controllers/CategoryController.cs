using Bazart.API.Services;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }
    }
}