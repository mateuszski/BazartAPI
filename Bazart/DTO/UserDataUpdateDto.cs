using System.ComponentModel.DataAnnotations;

namespace Bazart.API.DTO
{
    public class UserDataUpdateDto
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
    }
}
