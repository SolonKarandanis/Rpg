using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Services.Users
{
    public interface IUsersService
    {
        Task<User> FindById(int id, bool fetchCharacters);

        Task<List<User>> FindAll();

        Task<PageResponse<User>> FindAll(Paging paging);

        Task<bool> UserExistsByUsername(string username);

        Task<User> CreateUser(User user);

        Task<User> UpdateUser(User user);

        Task<int> DeleteUser(int userId);

        GetUserDto ConvertToDto(User user);

        User ConvertToEntity(GetUserDto dto);
    }
}