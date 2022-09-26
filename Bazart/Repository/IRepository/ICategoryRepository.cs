using Bazart.Models;

namespace Bazart.API.Repository.IRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> GetAllCategories();
    }
}