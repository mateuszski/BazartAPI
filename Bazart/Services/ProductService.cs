using AutoMapper;
using Bazart.DataAccess.Data;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazart.Services
{
    public class ProductService : IProductService
    {
        private readonly BazartDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(BazartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAllProducts([FromQuery] string? like = null)
        {
            var products = _dbContext
                .Products
                .Include(p => p.Categories)
                .ToList()
                .AsQueryable();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }

        public ProductDto GetProductById([FromRoute]int id)
        {
            var productsId = _dbContext
                .Products
                .Include(p => p.Categories)
                .FirstOrDefault(p => p.Id == id);
            if (productsId is null)
            {
                return null;
            }
            
            var productsIdDto = _mapper.Map<ProductDto>(productsId);
            return productsIdDto;
        }

        public int CreateNewProduct(CreateProductDto create)
        {
            var product = _mapper.Map<Product>(create);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product.Id;
        }

        public bool RemoveProduct(int id)
        {
            var isRemoveProduct = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (isRemoveProduct is null)
            {
                return false;
            }
            _dbContext.Products.Remove(isRemoveProduct);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
