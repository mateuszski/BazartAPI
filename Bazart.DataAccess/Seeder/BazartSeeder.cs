using Bazart.DataAccess.Data;
using Bazart.Models;

namespace Bazart.DataAccess.Seeder
{
    public class BazartSeeder
    {
        private readonly BazartDbContext _dbContext;

        public BazartSeeder(BazartDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Products.Any())
                {
                    var products = CreateRandomProducts();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Product> CreateRandomProducts()
        {
            Category pictureCategory = new Category()
            {
                Name = "obraz",
                Description = Faker.Lorem.Sentence()
            };

            var products = new List<Product>()
            {
                new Product()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(),
                    Price = Faker.Finance.Coupon(),
                    Quantity = Faker.RandomNumber.Next(1, 10),
                    isForSale = Faker.Boolean.Random(),
                    ImageUrl = Faker.Internet.Url(),
                    Categories = new List<Category>()
                    {
                        pictureCategory
                    }
                },
                new Product()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(),
                    Price = Faker.Finance.Coupon(),
                    Quantity = Faker.RandomNumber.Next(1, 10),
                    isForSale = Faker.Boolean.Random(),
                    ImageUrl = Faker.Internet.Url(),
                    Categories = new List<Category>()
                    {
                        pictureCategory
                    }
                },
                new Product()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(),
                    Price = Faker.Finance.Coupon(),
                    Quantity = Faker.RandomNumber.Next(1, 10),
                    isForSale = Faker.Boolean.Random(),
                    ImageUrl = Faker.Internet.Url(),
                    Categories = new List<Category>()
                    {
                        pictureCategory
                    }
                },
                new Product()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(),
                    Price = Faker.Finance.Coupon(),
                    Quantity = Faker.RandomNumber.Next(1, 10),
                    isForSale = Faker.Boolean.Random(),
                    ImageUrl = Faker.Internet.Url(),
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = Faker.Name.First(),
                            Description = Faker.Lorem.Sentence(),
                        }
                    }
                },
                new Product()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(),
                    Price = Faker.Finance.Coupon(),
                    Quantity = Faker.RandomNumber.Next(1, 10),
                    isForSale = Faker.Boolean.Random(),
                    ImageUrl = Faker.Internet.Url(),
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = Faker.Name.First(),
                            Description = Faker.Lorem.Sentence()
                        }
                    }
                },
                new Product()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(),
                    Price = Faker.Finance.Coupon(),
                    Quantity = Faker.RandomNumber.Next(1, 10),
                    isForSale = Faker.Boolean.Random(),
                    ImageUrl = Faker.Internet.Url(),
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = Faker.Name.First(),
                            Description = Faker.Lorem.Sentence()
                        }
                    }
                },new Product()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(),
                    Price = Faker.Finance.Coupon(),
                    Quantity = Faker.RandomNumber.Next(1, 10),
                    isForSale = Faker.Boolean.Random(),
                    ImageUrl = Faker.Internet.Url(),
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = Faker.Name.First(),
                            Description = Faker.Lorem.Sentence()
                        }
                    }
                }
            };
            return products;
        }
    }
}