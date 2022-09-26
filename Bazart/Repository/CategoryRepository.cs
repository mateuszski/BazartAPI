using AutoMapper;
using Bazart.API.Repository.IRepository;
using Bazart.DataAccess.Data;
using Bazart.Models;

namespace Bazart.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BazartDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(BazartDbContext dbContext, IMapper mapper)
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