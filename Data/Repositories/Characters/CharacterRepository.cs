using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Data.Repositories;

namespace rpg.Data.Repositories.Characters
{
    public class CharacterRepository :Repository<Character>, ICharacterRepository
    {
         private readonly DataContext context;

        public CharacterRepository(DataContext context):base(context)
        {
            this.context = context;
        }

        public async Task<bool> CharacterExists(string name)
        {
            if (await context.Characters
                .AnyAsync(u => u.Name.ToLower() == name.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Character>> FindByUserId(int userId)
        {
            return await context.Characters
                .Where(character=> character.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Character> FindById(int id, bool fetchRelations)
        {
            var charCtx= context.Characters;
            if(fetchRelations){
                charCtx.Include(character=>character.Weapons)
                    .Include(character=>character.Backpack)
                    .Include(character=>character.Factions)
                    .Include(character=>character.Skills);
            }

            return await charCtx.FindAsync(id);
        }

        public async Task<List<Character>> FindByIdsWithWeaponsAndSkills(List<int> characterIds)
        {
            return await context.Characters
                .Include(c=>c.Weapons)
                .Include(c=> c.Skills)
                .Where(c=> characterIds.Contains(c.Id))
                .ToListAsync();
        }
    }
}