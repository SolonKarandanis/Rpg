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

        public  GetCharacterDto ConvertToDto(Character character,bool convertRelationsShips)
        {
            var characterDto = mapper.Map<GetCharacterDto>(character);
            if(convertRelationsShips && ListUtils.IsEmpty(character.Skills)){
                var skillsDto = character.Skills
                    .Select(skill => mapper.Map<GetSkillDto>(skill))
                    .ToList();
                characterDto.Skills = skillsDto;
            }
            if(convertRelationsShips && ListUtils.IsEmpty(character.Factions)){
                var factionsDto = character.Factions
                    .Select(faction => mapper.Map<GetFactionDto>(faction))
                    .ToList();
                characterDto.Factions = factionsDto;
            }
            if(convertRelationsShips && ListUtils.IsEmpty(character.Weapons)){
                var weaponsDto = character.Weapons
                    .Select(weapon => mapper.Map<GetWeaponDto>(weapon))
                    .ToList();
                characterDto.Weapons = weaponsDto;
            }
            if(convertRelationsShips && character.Backpack is not null){
                characterDto.Backpack = mapper.Map<GetBackpackDto>(character.Backpack);
            }
            return characterDto;
        }

        public Character ConvertToEntity(GetCharacterDto dto)
        {
            return mapper.Map<Character>(dto);
        }

        public async Task<Character> CreateCharacter(AddCharacterDto character, int userId)
        {
            var user = await usersService.FindById(userId,false);
            var characterModel = new Character(){
                Name=character.Name,
                HitPoints=character.HitPoints,
                Strength=character.Strength,
                Defense=character.Defense,
                Intelligence=character.Intelligence,
                Class=character.Class,
                User=user,
                UserId=user.Id
            };
            var characterId= await charRepo.CreateCharacter(characterModel);
            return await FindById(characterId,true);

        }

        public async Task<int> DeleteCharacter(int id)
        {
            var existingCharacter = await FindById(id,false);
            
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

        public async Task<Character> UpdateCharacter(UpdateCharacterDto character)
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