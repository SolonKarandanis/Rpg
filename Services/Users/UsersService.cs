using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Services.Users
{
    public class UsersService : IUsersService
    {
        private IUserRepository userRepo;
        public UsersService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
            
        }
        public Task<GetUserDto> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetUserDto>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<PageResponse<GetUserDto>> FindAll(Paging paging)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserDto> FindById(int id, bool fetchCharacters)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserDto> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}