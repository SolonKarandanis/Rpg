using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Data.Repositories.Characters
{
    public class CharacterRepository : ICharacterRepository
    {
         private readonly DataContext context;

        public CharacterRepository(DataContext context)
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

        public async Task<int> CreateCharacter(Character character)
        {
            context.Characters.Add(character);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteCharacter(Character character)
        {
            context.Characters.Remove(character);
            return await context.SaveChangesAsync();
        }

        public async Task<PageResponse<Character>> FindAll(Paging paging)
        {
            var page = paging.Page -1;
            var pageResults = paging.Size;
            var totalNumber = context.Characters.Count();
            var pageCount = (totalNumber + page)/ paging.Page;
            var skippedElements = page * pageResults;
            var characters = await context.Characters
                .Skip(skippedElements)
                .Take(pageResults)
                .ToListAsync();
            var response = new PageResponse<Character>(characters,totalNumber,pageCount);
            return response;
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

        public async Task<int> UpdateCharacter(Character character)
        {
            context.Characters.Update(character);
            return await context.SaveChangesAsync();
        }
    }
}