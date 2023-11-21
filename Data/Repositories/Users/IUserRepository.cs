using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Data.Repositories;

namespace rpg.Data.Repositories.Users
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User?> FindByUsername(string username);

        Task<User> FindById(int id, bool fetchCharacters);


        Task<bool> UserExistsByUsername(string username);

        Task<bool> UserExists(int id);
        
    }
}