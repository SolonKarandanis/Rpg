using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace rpg.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository userRepo;
        private readonly IMapper mapper;
        public UsersService(IUserRepository userRepo,IMapper mapper)
        {
            this.userRepo = userRepo;
            this.mapper=mapper;
            
        }

        public GetUserDto ConvertToDto(User user)
        {
           return mapper.Map<GetUserDto>(user);
        }

        public User ConvertToEntity(GetUserDto dto)
        {
            return mapper.Map<User>(dto);
        }

        public async Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteUser(int userId)
        {
            var existingUser = await userRepo.FindById(userId,false);
            if(existingUser is null){
                throw new Exception("User does not exist");
            }
            return await userRepo.Delete(existingUser);
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            return await userRepo.FindAll();
        }

        public async Task<PageResponse<User>> FindAll(Paging paging)
        {
            var searchResult = await userRepo.FindAll(paging);
            
            return searchResult;
        }

        public async Task<User> FindById(int id, bool fetchCharacters)
        {
            var user = await userRepo.FindById(id,fetchCharacters);
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var updatedUserId = await userRepo.Update(user);
            var usr = await FindById(updatedUserId,true);
            return usr;
        }

        public async Task<bool> UserExistsByUsername(string username)
        {
            return await userRepo.UserExistsByUsername(username);
        }
    }
}