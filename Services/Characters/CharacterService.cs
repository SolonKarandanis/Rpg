using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using rpg.Data;

namespace rpg.Services.Characters
{
    public class CharacterService : ICharacterService
    {

        private readonly IMapper mapper;
        private readonly ICharacterRepository charRepo;
        private readonly IUsersService usersService;
        private readonly ISkillService skillsService;

        public CharacterService(
            IMapper mapper, 
            ICharacterRepository charRepo,
            IUsersService usersService,
            ISkillService skillsService)
        {
            this.mapper = mapper;
            this.charRepo = charRepo;
            this.usersService = usersService;
            this.skillsService = skillsService;
        }


        public async Task<bool> CharacterExists(string name)
        {
            return await charRepo.CharacterExists(name);
        }

        public  GetCharacterDto ConvertToDto(Character character)
        {
            return mapper.Map<GetCharacterDto>(character);
        }

        public Character ConvertToEntity(GetCharacterDto dto)
        {
            return mapper.Map<Character>(dto);
        }

        public async Task<Character> CreateCharacter(Character character, int userId)
        {
            var user = await usersService.FindById(userId,false);
            character.UserId = user.Id;
            character.User = user;

            var characterId= await charRepo.CreateCharacter(character);
            return await FindById(characterId,true);

        }

        public async Task<int> DeleteCharacter(int id)
        {
            var existingCharacter = await charRepo.FindById(id,false);
            if(existingCharacter is null){
                throw new Exception($"User with Id '{id}' not found.");
            }
            return await charRepo.DeleteCharacter(existingCharacter);
        }

        public async Task<PageResponse<Character>> FindAll(Paging paging)
        {
            return await charRepo.FindAll(paging);
        }


        public async Task<Character> FindById(int id, bool fetchRelations)
        {
            var character = await charRepo.FindById(id,fetchRelations);
            if(character is null){
                throw new Exception($"Character with Id '{id}' not found.");
            }
            return character;
        }

        public async Task<List<Character>> FindByUserId(int userId)
        {
            return await charRepo.FindByUserId(userId);
        }

        public async Task<Character> UpdateCharacter(Character character)
        {
            var characterId = character.Id;
            var existingCharacter = await FindById(characterId,false);
            existingCharacter.Name = character.Name;
            existingCharacter.HitPoints = character.HitPoints;
            existingCharacter.Strength = character.Strength;
            existingCharacter.Defense = character.Defense;
            existingCharacter.Intelligence = character.Intelligence;
            existingCharacter.Class = character.Class;

            await charRepo.UpdateCharacter(existingCharacter);
            return existingCharacter;
        }

        public async Task<Character> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            var existingCharacter = await FindById(newCharacterSkill.CharacterId,true);
            var selectedSkill = await skillsService.FindById(newCharacterSkill.SkillId);
            existingCharacter!.Skills!.Add(selectedSkill);
            await charRepo.UpdateCharacter(existingCharacter);
            return existingCharacter;
        }
    }
}