using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegisterDto userDto);
        Task<ServiceResponse<string>> Login(string username, string password);
    }
}