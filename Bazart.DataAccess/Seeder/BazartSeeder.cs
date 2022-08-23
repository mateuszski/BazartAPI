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
                    var mainUser = CreateUser("Main", "Owner");
                    var products = CreateCustomProducts(mainUser);
                    var randomProduct = CreateRandomProduct();
                    var shoppingCartProducts = new List<Product>()
                    {
                        products.ElementAt(1),
                        products.ElementAt(2),
                        products.ElementAt(0),
                        CreateRandomProduct(),
                        CreateRandomProduct(),
                        CreateRandomProduct()
                    };
                    var order = new Order()
                    {
                        User = mainUser,
                        OrderDate = DateTime.Now
                    };
                    _dbContext.Users.AddRange(mainUser);
                    _dbContext.Products.AddRange(products);
                    _dbContext.Events.AddRange(CreatEvent(mainUser));
                    _dbContext.Orders.AddRange(order);
                    //_dbContext.OrderProducts.AddRange(CreateOrderProduct());
                    _dbContext.SaveChanges();
                }
            }
        }

        public List<OrderProduct> CreateOrderProduct(List<Product> orderedProducts, int orderId)
        {
            var orderProducts = new List<OrderProduct>();
            foreach (var product in orderedProducts)
            {
                var newOrderProduct = new OrderProduct()
                {
                    //OrderId = orderId,
                    ProductId = product.Id
                };
                orderProducts.Add(newOrderProduct);
            }
            return orderProducts;
        }

        private Order CreateOrder(User user)
        {
            var order = new Order()
            {
                User = user,
                OrderDate = DateTime.Now,
                //OrderProducts = CreateOrderProduct();
            };
            return order;
        }

        private Event CreatEvent(User eventOwner)
        {
            Event newEvent = new Event()
            {
                Name = Faker.Name.FullName(),
                Description = Faker.Lorem.Words(6).ToString(),
                Adress = "Kraków",
                Owner = eventOwner,
                Users = new List<User>()
                {
                    CreateUser("Participant1","123"),
                    CreateUser("Participant2","123"),
                    CreateUser("Participant3","123")
                },
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
                Products = new List<Product>(),
                Events = new List<Event>(),
                Orders = new List<Order>()
            };
            return user;
        }

        private IEnumerable<Product> CreateCustomProducts(User user)
        {
            Category pictureCategory = new Category()
            {
                Name = "Obraz",
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
                    OrderProducts = new List<OrderProduct>(),
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
                    OrderProducts = new List<OrderProduct>(),
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
                    OrderProducts = new List<OrderProduct>(),
                    User = user
                }
            };
            return products;
        }

        public Product CreateRandomProduct()
        {
            Product randProduct = new Product()
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
                OrderProducts = new List<OrderProduct>(),
                User = CreateUser("Norbert", "Lewandowski")
            };
            return randProduct;
        }
    }
}