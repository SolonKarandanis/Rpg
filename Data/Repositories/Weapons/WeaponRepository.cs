using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Data.Repositories.Weapons
{
    public class WeaponRepository : IWeaponRepository
    {

        private readonly DataContext context;

        public WeaponRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateWeapon(Weapon weapon)
        {
            context.Weapons.Add(weapon);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteWeapon(Weapon weapon)
        {
            context.Weapons.Remove(weapon);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Weapon>> FindByCharacterId(int characterId)
        {
            return await context.Weapons
                .Where(weapon => weapon.CharacterId == characterId)
                .ToListAsync();
        }

        public async Task<Weapon> FindById(int id)
        {
           return await context.Weapons.FindAsync(id);
        }
    }
}