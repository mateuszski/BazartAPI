using AutoMapper;
using Bazart.API.DTO;
using Bazart.API.Exceptions;
using Bazart.API.Repository.IRepository;
using Bazart.DataAccess.Data;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazart.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly BazartDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(BazartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _dbContext
               .Products
               .Include(p => p.Categories)
               //.Include(p => p.User)
               .ToList();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }

        public ProductDto GetProductById([FromRoute] int id)
        {
            var productsId = _dbContext
                .Products
                .Include(p => p.Categories)
                .FirstOrDefault(p => p.Id == id);
            if (productsId is null)
            {
                throw new NotFoundException("Product not found.");
            }

            var productsIdDto = _mapper.Map<ProductDto>(productsId);
            return productsIdDto;
        }

        public Product GetProductWithUserById([FromRoute] int productId)
        {
            var product = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == productId);

            if (product is null)
            {
                throw new NotFoundException("Product not found.");
            }

            return product;
        }

        public IEnumerable<ProductDto> GetProductsByUserId([FromRoute] int id)
        {
            var productsByUserId = _dbContext
                .Products
                .Include(p => p.Categories)
                .Where(p => p.User.Id == id);
            if (productsByUserId is null)
            {
                throw new NotFoundException("Product not found.");
            }
            var productsByUserIdDto = _mapper.Map<List<ProductDto>>(productsByUserId);
            return productsByUserIdDto;
        }

        public Product GetProductToRemove(int userId)
        {
            var userProductId = _dbContext.Products.FirstOrDefault(p => p.UserId == userId);
            if (userProductId is null)
            {
                throw new NotFoundException("Product not found.");
            }
            return userProductId;
        }

        public IEnumerable<ProductDto> GetLatestProducts()
        {
            var latestProducts = _dbContext
                .Products
                .Include(p => p.Categories)
                .OrderByDescending(p => p.Id)
                .Take(2);
            var latestProductsDto = _mapper.Map<List<ProductDto>>(latestProducts);

            return latestProductsDto;
        }

        public int CreateNewProduct(CreateProductDto create)
        {
            var product = _mapper.Map<Product>(create);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product.Id;
        }

        public void RemoveProduct(int id)
        {
            var isRemoveProduct = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (isRemoveProduct is null)
            {
                throw new NotFoundException("Product not found");
            }

            _dbContext.Products.Remove(isRemoveProduct);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(int id, UpdateProductDto update)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }

            product.Name = update.Name;
            product.Description = update.Description;
            product.Price = (decimal)update.Price;
            product.Quantity = update.Quantity;
            product.isForSale = update.isForSale;
            product.ImageUrl = update.ImageUrl;
            _dbContext.SaveChanges();
        }
    }
}