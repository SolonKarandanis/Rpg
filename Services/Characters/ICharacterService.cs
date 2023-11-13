using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace rpg.Services.Characters
{
    public interface ICharacterService
    {

        GetCharacterDto ConvertToDto(Character character, bool convertRelationsShips);

        Character ConvertToEntity(GetCharacterDto dto);

        Task<bool> CharacterExists(string name);

        Task<Character> CreateCharacter(AddCharacterDto character, int userId);

        Task<Character> UpdateCharacter(UpdateCharacterDto character);

        Task<int> DeleteCharacter(int id);

        Task<PageResponse<Character>> FindAll(Paging paging);

        Task<Character> FindById(int id, bool fetchRelations);

        Task<List<Character>> FindByUserId(int userId);

        Task<Character> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);

        public Task<List<Character>> FindByIdsWithWeaponsAndSkills(List<int> characterIds);

        Task<int> UpdateRange(IEnumerable<Character> entities);
    }
}