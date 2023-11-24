using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Data.Repositories;

namespace rpg.Data.Repositories.Weapons
{
    public interface IWeaponRepository: IRepository<Weapon>
    {

        Task<List<Weapon>> FindByCharacterId(int characterId);

        Task<bool> ExistsByCharacterIdAndType(int characterId,WeaponType Type);

        Task<int> DeleteByCharacterId(int characterId);

    }
}