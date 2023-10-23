using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id=1,Name="Sam"}
        };
        private readonly IMapper mapper;

        public CharacterService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<CharacterDto>>();
            var character = mapper.Map<Character>(newCharacter);
            characters.Add(character);
            serviceResponse.Data = characters
                .Select(c=> mapper.Map<CharacterDto>(c))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> GetAllCharracters()
        {
            var dtoList = characters
                .Select(c=> mapper.Map<CharacterDto>(c))
                .ToList();
            var serviceResponse = new ServiceResponse<List<CharacterDto>>(){Data= dtoList};
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDto>> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c=> c.Id ==id);
            var dto = mapper.Map<CharacterDto>(character);
            var serviceResponse = new ServiceResponse<CharacterDto>(){Data = dto};
            return serviceResponse;
        }
    }
}