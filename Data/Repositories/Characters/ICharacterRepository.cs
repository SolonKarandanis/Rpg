using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Data.Repositories;

namespace rpg.Data.Repositories.Characters
{
    public interface ICharacterRepository : IRepository<Character>
    {

        public Task<Character?> FindById(int id,bool fetchRelations);

        public Task<List<Character>> FindByUserId(int userId);

        public Task<bool> CharacterExists(string name);

        public Task<List<Character>> FindByIdsWithWeaponsAndSkills(List<int> characterIds);
        
    }
}