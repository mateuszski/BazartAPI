using Bazart.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Repository.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<UserDto> GetAllUsers();

        UserDto GetUserById([FromRoute] int id);

        int CreateNewUser(UserFirstRegistarationDto create);

        void RemoveUser(int id);

        void UpdateUser(int id, UserDataUpdateDto update);

        bool CheckIfUserExist(string email);

        byte[] GetPasswordHashByUserEmail(string userEmail);

        byte[] GetPasswordSaltByUserEmail(string userEmail);

        UserDto GetUserByEmail([FromRoute] string email);

        int GetUserIdByEmail(string email);
    }
}