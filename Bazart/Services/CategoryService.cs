using AutoMapper;
using Bazart.DataAccess.Data;
using Bazart.Models;

namespace Bazart.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BazartDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(BazartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _dbContext.Categories.ToList();
            var categoriesDdo = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesDdo;
        }
    }
}