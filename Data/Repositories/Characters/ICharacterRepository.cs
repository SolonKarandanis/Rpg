using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Data.Repositories.Characters
{
    public interface ICharacterRepository
    {
        public Task<PageResponse<Character>> FindAll(Paging paging);

        public Task<Character> FindById(int id,bool fetchRelations);

        public Task<List<Character>> FindByUserId(int userId);

        public Task<bool> CharacterExists(string name);

        public Task<int> CreateCharacter(Character character);

        public Task<int> UpdateCharacter(Character character);

        public Task<int> DeleteCharacter(Character character);
        
    }
}