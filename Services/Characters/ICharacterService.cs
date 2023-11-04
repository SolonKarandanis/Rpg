using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace rpg.Services.Characters
{
    public interface ICharacterService
    {

        GetCharacterDto ConvertToDto(Character character);

        Character ConvertToEntity(GetCharacterDto dto);

        Task<bool> CharacterExists(string name);

        Task<Character> CreateCharacter(Character character, int userId);

        Task<Character> UpdateCharacter(Character character);

        Task<int> DeleteCharacter(int id);

        Task<PageResponse<Character>> FindAll(Paging paging);

        Task<Character> FindById(int id, bool fetchRelations);

        Task<List<Character>> FindByUserId(int userId);

        Task<Character> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
    }
}