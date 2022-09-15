using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Bazart.Models;

namespace Bazart.API.DTO
{
    public class UserDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(75)]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
        //public int UserId { get; set; }

        //[AllowNull]
        //public List<Product> Products { get; set; }
        //public List<Event> OwnedEvents { get; set; }
        //public List<Event> Events { get; set; }
        //[AllowNull]
        //public List<Order> Orders { get; set; }
    }
}