using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace rpg
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
            CreateMap<UserRegisterDto,User>();
            CreateMap<GetUserDto,User>();
            CreateMap<User,GetUserDto>();
            CreateMap<AddWeaponDto,Weapon>();
            CreateMap<GetWeaponDto,Weapon>();
            CreateMap<Weapon,GetWeaponDto>();
        }
    }
}