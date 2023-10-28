using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Data.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> FindByUsername(string username);

        Task<User> FindById(int id, bool fetchCharacters);

        Task<List<User>> FindAll();

        Task<bool> UserExists(string username);

        Task<int> CreateUser(User user);

        Task<int> UpdateUser(User user);

        Task<int> DeleteUser(User user);
        
    }
}