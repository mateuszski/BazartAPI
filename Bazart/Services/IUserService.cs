using Bazart.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Services;

public interface IUserService
{
    IEnumerable<UserDto> GetAllUsers();
    UserDto GetUserById([FromRoute] int id);
    int CreateNewUser(UserFirstRegistarationDto create);
    void RemoveUser(int id);
    void UpdateUser(int id, UserDataUpdateDto update);
}