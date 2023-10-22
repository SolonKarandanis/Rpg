using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetAllCharracters();
        Character GetCharacterById(int id);

        List<Character> AddCharacter(Character newCharacter);
    }
}