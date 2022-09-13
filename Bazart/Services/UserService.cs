using AutoMapper;
using Bazart.API.DTO;
using Bazart.API.Exceptions;
using Bazart.DataAccess.Data;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazart.API.Services
{


    public class UserService :  IUserService
    {
        private readonly BazartDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(BazartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _dbContext.Users
                .ToList();

            var usersDto = _mapper.Map<List<UserDto>>(users);

            return usersDto;
        }

        public UserDto GetUserById([FromRoute] int id)
        {
            var userById = _dbContext
                .Users
                .FirstOrDefault(p => p.Id == id);
            if (userById is null)
            {
                throw new NotFoundException("User not found.");
            }

            var userByIdDto = _mapper.Map<UserDto>(userById);
            return userByIdDto;
        }



        public int CreateNewUser(UserFirstRegistarationDto create)
        {
            var user = _mapper.Map<User>(create);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public void RemoveUser(int id)
        {
            var isUser = _dbContext.Users.FirstOrDefault(p => p.Id == id);
            if (isUser is null)
            {
                throw new NotFoundException("User not found");
            }
            _dbContext.Users.Remove(isUser);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(int id, UserDataUpdateDto update)
        {
            var user = _dbContext.Users.FirstOrDefault(p => p.Id == id);
            if (user is null)
            {
                throw new NotFoundException("User not found");
            }

            user.FirstName = update.FirstName;
            user.Email = update.Email;
            user.LastName = update.LastName;
            user.PhoneNumber = update.PhoneNumber;
            _dbContext.SaveChanges();
        }

        public bool CheckIfUserExist(UserLoginDto request)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == request.Email);

            if (user is null)
            {
                return false;
            }
            return true;
        }


        public byte[] GetPasswordSaltByUserEmail(string userEmail)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
            return user.PasswordSalt;
        }

        public byte[] GetPasswordHashByUserEmail(string userEmail)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
            return user.PasswordHash;
        }
    }
}