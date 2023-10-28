using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using rpg.Data;

namespace rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id=1,Name="Sam"}
        };
        private readonly IMapper mapper;
        private readonly DataContext context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = mapper.Map<Character>(newCharacter);
            characters.Add(character);
            serviceResponse.Data = characters
                .Select(c=> mapper.Map<GetCharacterDto>(c))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try{
                var character = characters.First(c=> c.Id ==id);
                if (character is null)
                    throw new Exception($"Character with Id '{id}' not found.");
                characters.Remove(character);
                var dtoList = characters
                    .Select(c=> mapper.Map<GetCharacterDto>(c))
                    .ToList();
                serviceResponse.Data= dtoList;

            }catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharracters()
        {
            var dbCharacters = await context.Characters.ToListAsync();
            var dtoList = dbCharacters
                .Select(c=> mapper.Map<GetCharacterDto>(c))
                .ToList();
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>(){Data= dtoList};
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c=> c.Id ==id);
            var dto = mapper.Map<GetCharacterDto>(character);
            var serviceResponse = new ServiceResponse<GetCharacterDto>(){Data = dto};
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character)
        
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var c = characters.FirstOrDefault(c=> c.Id ==character.Id);
                if (c is null)
                    throw new Exception($"Character with Id '{character.Id}' not found.");

                c.Name = character.Name;
                c.HitPoints = character.HitPoints;
                c.Strength = character.Strength;
                c.Defense = character.Defense;
                c.Intelligence = character.Intelligence;
                c.Class = character.Class;
                var dto = mapper.Map<GetCharacterDto>(c);
                serviceResponse.Data = dto;
            
            
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
            
        }

    }
}