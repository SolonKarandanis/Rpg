using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Data.Repositories;

namespace rpg.Data.Repositories.Weapons
{
    public class WeaponRepository :Repository<Weapon>, IWeaponRepository,IDisposable
    {

        private readonly DataContext context;

        public WeaponRepository(DataContext context):base(context)
        {
            this.context = context;
        }

        public async Task<int> DeleteByCharacterId(int characterId)
        {
            return await context.Weapons
                .Where(w=> w.CharacterId == characterId)
                .ExecuteDeleteAsync();
        }

        public async Task<bool> ExistsByCharacterIdAndType(int characterId, WeaponType type)
        {
            var exists =await context.Weapons
                    .AnyAsync(w => w.CharacterId == characterId && w.Type == type);
            if(exists){
                return true;
            }
            return false;
        }

        public async Task<List<Weapon>> FindByCharacterId(int characterId)
        {
            return await context.Weapons
                .Where(weapon => weapon.CharacterId == characterId)
                .ToListAsync();
        }

        public async void Dispose()
        {
            await context.DisposeAsync();
            GC.SuppressFinalize(this);
        }

    }
}