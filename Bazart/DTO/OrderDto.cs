using Bazart.Models;

namespace Bazart.API.DTO
{
    public class OrderDto
    {
        public int UserId { get; set; }
        //public User User { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
