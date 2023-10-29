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

        public async Task<GetUserDto> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteUser(User user)
        {
            return await userRepo.DeleteUser(user);
        }

        public async Task<List<GetUserDto>> FindAll()
        {
            var users = await userRepo.FindAll();
            var userDtos = users
                .Select(ConvertToDto)
                .ToList();
            return userDtos;
        }

        public async Task<PageResponse<GetUserDto>> FindAll(Paging paging)
        {
            var searchResult = await userRepo.FindAll(paging);
            var usersDto = searchResult.Content
                .Select(ConvertToDto)
                .ToList();
            var result = new PageResponse<GetUserDto>(usersDto,searchResult.TotalNumber,searchResult.PageCount);
            return result;
        }

        public async Task<GetUserDto> FindById(int id, bool fetchCharacters)
        {
            var user = await userRepo.FindById(id,fetchCharacters);
            var userDto = ConvertToDto(user);
            return userDto;
        }

        public async Task<GetUserDto> UpdateUser(User user)
        {
            var updatedUserId = await userRepo.UpdateUser(user);
            var usr = await FindById(updatedUserId,true);
            return usr;
        }

        public async Task<bool> UserExists(string username)
        {
            return await userRepo.UserExists(username);
        }
    }
}