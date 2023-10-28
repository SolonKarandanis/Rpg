using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Data.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> FindUserByUsername(string username);

        Task<bool> UserExists(string username);

        Task<int> CreateUser(User user);
    }
}