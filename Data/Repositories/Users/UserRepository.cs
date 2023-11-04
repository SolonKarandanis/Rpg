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

        public async Task<int> DeleteUser(User user)
        {
            context.Users.Remove(user);
            return await context.SaveChangesAsync();
        }

        public async Task<List<User>> FindAll()
        {
           return await context.Users.ToListAsync();
        }

        public async Task<PageResponse<User>> FindAll(Paging paging)
        {
            var page = paging.Page -1;
            var pageResults = paging.Size;
            var totalNumber = context.Users.Count();
            var pageCount = (totalNumber + page)/ paging.Page;
            var skippedElements = page * pageResults;
            var users = await context.Users
                .Skip(skippedElements)
                .Take(pageResults)
                .ToListAsync();
            var response = new PageResponse<User>(users,totalNumber,pageCount);
            return response;
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

        public async Task<int> UpdateUser(User user)
        {
            context.Users.Update(user);
            return await context.SaveChangesAsync();
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