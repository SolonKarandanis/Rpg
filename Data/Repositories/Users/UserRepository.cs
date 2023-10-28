using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Data.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateUser(User user)
        {
            context.Users.Add(user);
            return await context.SaveChangesAsync();
        }

        public async Task<User> FindUserByUsername(string username)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));
            return user;
        }

        public async Task<bool> UserExists(string username)
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