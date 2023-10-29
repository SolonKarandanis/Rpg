using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Services.Users
{
    public interface IUsersService
    {
        Task<GetUserDto> FindById(int id, bool fetchCharacters);

        Task<List<GetUserDto>> FindAll();

        Task<PageResponse<GetUserDto>> FindAll(Paging paging);

        Task<bool> UserExists(string username);

        Task<GetUserDto> CreateUser(User user);

        Task<GetUserDto> UpdateUser(User user);

        Task<int> DeleteUser(User user);
    }
}