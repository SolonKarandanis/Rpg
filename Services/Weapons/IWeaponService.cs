using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Services.Weapons
{
    public interface IWeaponService
    {
        Task<GetWeaponDto> AddWeapon(Weapon weapon);

        Task<GetWeaponDto> FindById(int id);

        Task<List<GetWeaponDto>> FindByCharacterId(int characterId);

        Task<List<GetWeaponDto>> DeleteWeapon(Weapon weapon);

        GetWeaponDto ConvertToDto(Weapon weapon);

        Weapon ConvertToEntity(GetWeaponDto dto);
    }
}