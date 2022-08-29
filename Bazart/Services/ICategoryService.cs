using Bazart.Models;

namespace Bazart.API.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
    }
}