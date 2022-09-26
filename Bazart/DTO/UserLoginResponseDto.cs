using Bazart.Models;

namespace Bazart.API.DTO
{
    public class UserLoginResponseDto
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}