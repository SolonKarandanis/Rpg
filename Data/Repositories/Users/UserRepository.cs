using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Data.Repositories;

namespace rpg.Data.Repositories.Users
{
    public class UserRepository :Repository<User>, IUserRepository,IDisposable
    {
        private readonly DataContext context;

        public UserRepository(DataContext context):base(context)
        {
            this.context = context;
        }

        private static Func<DataContext,string, Task<User?>> GetUserByUsername= 
            EF.CompileAsyncQuery((DataContext context,string username) => 
                context.Users.FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower())));


        public async Task<User?> FindById(int id,bool fetchCharacters)
        {
            var userCtx= context.Users;
            if(fetchCharacters){
                userCtx.Include(usr=>usr.Characters);
            }

            return await userCtx.FindAsync(id);
        }

        public async Task<User?> FindByUsername(string username)
        {

            return await GetUserByUsername(this.context, username);
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

        public async void Dispose()
        {
            await context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}