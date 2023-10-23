using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterDto>>> GetAllCharracters();
        Task<ServiceResponse<CharacterDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<CharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
    }
}