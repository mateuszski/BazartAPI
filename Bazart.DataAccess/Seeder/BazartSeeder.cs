using System.Text;
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
                    _dbContext.SaveChanges();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                    _dbContext.Events.AddRange(CreatEvent(mainUser));
                    _dbContext.SaveChanges();
                    _dbContext.Orders.AddRange(order);
                    _dbContext.SaveChanges();
                    _dbContext.OrderProducts.AddRange(CreateOrderProduct(products, 1));
                    _dbContext.SaveChanges();
                }
            }
        }

        public OrderProduct CreateOrderProduct(IEnumerable<Product> orderedProducts, int orderId)
        {
            //var orderProducts = new List<OrderProduct>();
            //foreach (var product in orderedProducts)
            //{
            //    var newOrderProduct = new OrderProduct()
            //    {
            //        OrderId = orderId,
            //        ProductId = product.Id
            //    };
            //    orderProducts.Add(newOrderProduct);
            //}
            OrderProduct orderProducts = new OrderProduct()
            {
                OrderId = 1,
                ProductId = 1
            };
            return orderProducts;
        }

        private Order CreateOrder(User user)
        {
            var order = new Order()
            {
                User = user,
                OrderDate = DateTime.Now,
                OrderProducts = new List<OrderProduct>()
            };
            return order;
        }

        private List<Event> CreatEvent(User eventOwner)
        {
            List<Event> newEvent = new List<Event>()
            {
                new Event()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(50),
                    Adress = "Kraków",
                    Owner = eventOwner,
                    Users = new List<User>()
                    {
                        CreateUser("Participant1", "123"),
                        CreateUser("Participant2", "123"),
                        CreateUser("Participant3", "123")
                    },
                    ImageUrl =
                        "https://images.unsplash.com/photo-1513818433747-5f175a60caee?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aW1nfHx8fHx8MTY2NDQzNjcxNQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    MapLat = 44,
                    MapLng = -80
                },
                new Event()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(50),
                    Adress = "Kraków",
                    Owner = eventOwner,
                    Users = new List<User>()
                    {
                        CreateUser("Participant1", "123"),
                        CreateUser("Participant2", "123"),
                        CreateUser("Participant3", "123")
                    },
                    ImageUrl =
                        "https://images.unsplash.com/photo-1514441615332-67834d513dea?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZXZlbnR8fHx8fHwxNjY0NDQyNzU4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    MapLat = 44,
                    MapLng = -80
                },
                new Event()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(50),
                    Adress = "Kraków",
                    Owner = eventOwner,
                    Users = new List<User>()
                    {
                        CreateUser("Participant1", "123"),
                        CreateUser("Participant2", "123"),
                        CreateUser("Participant3", "123")
                    },
                    ImageUrl =
                        "https://images.unsplash.com/photo-1496024840928-4c417adf211d?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZXZlbnR8fHx8fHwxNjY0NDQyODM2&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    MapLat = 44,
                    MapLng = -80
                },
                new Event()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(50),
                    Adress = "Kraków",
                    Owner = eventOwner,
                    Users = new List<User>()
                    {
                        CreateUser("Participant1", "123"),
                        CreateUser("Participant2", "123"),
                        CreateUser("Participant3", "123")
                    },
                    ImageUrl =
                        "https://images.unsplash.com/photo-1635321101901-7ac6eec3d371?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZXZlbnR8fHx8fHwxNjY0NDQyODg2&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    MapLat = 44,
                    MapLng = -80
                },
                new Event()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(50),
                    Adress = "Kraków",
                    Owner = eventOwner,
                    Users = new List<User>()
                    {
                        CreateUser("Participant1", "123"),
                        CreateUser("Participant2", "123"),
                        CreateUser("Participant3", "123")
                    },
                    ImageUrl =
                        "https://images.unsplash.com/photo-1598387993281-cecf8b71a8f8?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZXZlbnR8fHx8fHwxNjY0NDQyOTIz&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    MapLat = 44,
                    MapLng = -80
                },
                new Event()
                {
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(50),
                    Adress = "Kraków",
                    Owner = eventOwner,
                    Users = new List<User>()
                    {
                        CreateUser("Participant1", "123"),
                        CreateUser("Participant2", "123"),
                        CreateUser("Participant3", "123")
                    },
                    ImageUrl =
                        "https://images.unsplash.com/photo-1572177147505-c44e97033921?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZXZlbnR8fHx8fHwxNjY0NDU1MTA4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    MapLat = 44,
                    MapLng = -80
                }
            };
            return newEvent;
        }

        private User CreateUser(string firstName, string secondName)
        {
            User user = new User()
            {
                FirstName = firstName,
                LastName = secondName,
                Email = "1234@gmail.com",
                PhoneNumber = "12345678",
                PasswordHash = Encoding.UTF8.GetBytes("123"),
                PasswordSalt = Encoding.UTF8.GetBytes("123"),
                Products = new List<Product>(),
                Events = new List<Event>(),
                Orders = new List<Order>(),
                Role = "",
            };
            return user;
        }

        private IEnumerable<Product> CreateCustomProducts(User user)
        {
            Category pictureCategory = new Category()
            {
                Name = "Malarstwo",
                Description = Faker.Lorem.Sentence(),
                ImageUrl = "https://images.unsplash.com/photo-1460661419201-fd4cecdf8a8b?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YXJ0fHx8fHx8MTY2NDQ0MDg5Mw&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800"
            };

            Category sculptureCategory = new Category()
            {
                Name = "Rzeźba",
                Description = Faker.Lorem.Sentence(),
                ImageUrl = "https://images.unsplash.com/photo-1576875813198-8060631a39ba?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c2N1bHB0dXJlfHx8fHx8MTY2NDQ0MjQ2OA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800"
            };
            Category fotographyCategory = new Category()
            {
                Name = "Fotografia",
                Description = Faker.Lorem.Sentence(),
                ImageUrl = "https://images.unsplash.com/photo-1445090909078-0217954421ec?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8d29tYW58fHx8fHwxNjY0NDQyMjc3&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800"
            };
            Category handMadeCategory = new Category()
            {
                Name = "Rękodzieło",
                Description = Faker.Lorem.Sentence(),
                ImageUrl = "https://images.unsplash.com/photo-1507022787381-b30170b5ebf4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFuZG1hZGV8fHx8fHwxNjY0NDQxNjQ0&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800"
            };
            Category graphicArtsCategory = new Category()
            {
                Name = "Grafika Komputerowa",
                Description = Faker.Lorem.Sentence(),
                ImageUrl = "https://images.unsplash.com/photo-1627163439134-7a8c47e08208?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Z3JhcGhpY3x8fHx8fDE2NjQ0NDE4Mzg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800"
            };
            Category otherCategory = new Category()
            {
                Name = "Inne",
                Description = Faker.Lorem.Sentence(),
                ImageUrl = "https://images.unsplash.com/photo-1551732998-9573f695fdbb?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YXJ0fHx8fHx8MTY2NDQ0MTEyNg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800"
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
                        sculptureCategory
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
                        fotographyCategory
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
                        handMadeCategory
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
                        graphicArtsCategory
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
                        otherCategory
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