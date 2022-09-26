using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AutoMapper;
using Bazart.API.DTO;
using Bazart.API.Repository.IRepository;
using Bazart.API.Repository;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Bazart.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var firstUser = new UserFirstRegistarationDto()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
            };

            _userRepository.CreateNewUser(firstUser);

            return Ok(firstUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            var isUser = _userRepository.CheckIfUserExist(request);

            if (isUser == false)
            {
                return BadRequest("User not found");
            }

            if (!VerifyPasswordHash(request.Password, request.Email))
            {
                return BadRequest("Wrong password");
            }

            var userByEmail = _userRepository.GetUserByEmail(request.Email);
            //var user = _userRepository.GetUserById()
            string token = CreateToken(userByEmail);

            return Ok(token);
        }

        private string CreateToken(UserDto user)
        {
            var userId = _userRepository.GetUserIdByEmail(user.Email);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };
            //new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            var key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, string userEmail)
        {
            var userSalt = _userRepository.GetPasswordSaltByUserEmail(userEmail);
            var userHash = _userRepository.GetPasswordHashByUserEmail(userEmail);
            using (var hmac = new HMACSHA512(userSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(userHash);
            };
        }
    }
}