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
                    //var mainUser = CreateUser("Main", "Owner");
                    //var products = CreateRandomProducts(mainUser);
                    //var shoppingCartProducts = new List<Product>()
                    //{
                    //    products.ElementAt(2),
                    //    products.ElementAt(3),
                    //    products.ElementAt(5)

                    //};
                    //var shoppingCart = new ShoppingCart()
                    //{
                    //    User = mainUser,
                    //    Products = shoppingCartProducts
                    //};
                    //_dbContext.Users.AddRange(mainUser);
                    //_dbContext.Products.AddRange(products);
                    //_dbContext.Events.AddRange(CreatEvent(mainUser));
                    //_dbContext.ShoppingCarts.AddRange(shoppingCart);
                    //_dbContext.SaveChanges();
                }
            }
        }

        private ShoppingCart CreateShoppingCart(User user, List<Product> products)
        {
            var shoppingCart = new ShoppingCart()
            {
                //User = user,
                //Products = products
            };
            return shoppingCart;
        }

        private Event CreatEvent(User eventOwner)
        {
            Event newEvent = new Event()
            {
                Name = Faker.Name.FullName(),
                Description = Faker.Lorem.Words(6).ToString(),
                Adress = "Kraków",
                //Owner = eventOwner,
                //Users = new List<User>()
                //{
                //    CreateUser("Participant1","123"),
                //    CreateUser("Participant2","123"),
                //    CreateUser("Participant3","123")
                //},
                ImageUrl = "imageUrlHere",
            };
            return newEvent;
        }

        private User CreateUser(string firstName, string secondName)
        {
            User user = new  User()
            {
                FirstName =firstName,
                LastName = secondName,
                Email = "1234@gmail.com",
                PhoneNumber = "12345678",
                Password = "123",
                Products = null,
                //Events = null,
                ShoppingCart = null
            };
            return user;
        }

        private IEnumerable<Product> CreateRandomProducts(User user)
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
                    },
                    User = user
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
                    },
                    User = user
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
                    },
                    User = user
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
                    },
                    User = CreateUser("Pawel","Kowalski")
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
                    },
                    User = CreateUser("Norbert","Lewandowski")
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
                    },
                    User = CreateUser("Jakub","Nowak")

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
                    },
                    User = CreateUser("cos1","cos2")
                }
            };
            return products;
        }
    }
}