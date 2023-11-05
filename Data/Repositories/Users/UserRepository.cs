using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Data.Repositories;

namespace rpg.Data.Repositories.Users
{
    public class UserRepository :Repository<User>, IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context):base(context)
        {
            this.context = context;
        }


        public async Task<User> FindById(int id,bool fetchCharacters)
        {
            var userCtx= context.Users;
            if(fetchCharacters){
                userCtx.Include(usr=>usr.Characters);
            }

            return await userCtx.FindAsync(id);
        }

        public async Task<User> FindByUsername(string username)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));
            return user;
        }

        public async Task<bool> UserExists(int id)
        {
            if (await context.Users
                .AnyAsync(u => u.Id == id))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UserExistsByUsername(string username)
        {
            if (await context.Users
                .AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}