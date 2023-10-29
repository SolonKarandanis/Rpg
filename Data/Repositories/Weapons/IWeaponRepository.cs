using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Data.Repositories.Weapons
{
    public interface IWeaponRepository
    {
        Task<Weapon> FindById(int id);

        Task<List<Weapon>> FindByCharacterId(int characterId);

        Task<bool> ExistsByCharacterIdAndType(int characterId,WeaponType Type);

        Task<int> CreateWeapon(Weapon weapon);

        Task<int> DeleteWeapon(Weapon weapon);
    }
}