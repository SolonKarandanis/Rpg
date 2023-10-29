using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Services.Weapons
{
    public class WeaponService : IWeaponService
    {
        private readonly IWeaponRepository weaponRepo;
        private readonly IMapper mapper;

        public WeaponService(IWeaponRepository weaponRepo,IMapper mapper)
        {
            this.weaponRepo = weaponRepo;
            this.mapper=mapper;
        }

        public GetWeaponDto ConvertToDto(Weapon weapon)
        {
            return mapper.Map<GetWeaponDto>(weapon);
        }

        public Weapon ConvertToEntity(GetWeaponDto dto)
        {
            return mapper.Map<Weapon>(dto);
        }

        public async Task<GetWeaponDto> AddWeapon(Weapon weapon)
        {
            var characterId = weapon.CharacterId;
            var type = weapon.Type;
            if(await weaponRepo.ExistsByCharacterIdAndType(characterId,type)){
                throw new ArgumentException("Weapon exists for Character");
            }
            var weaponId = await weaponRepo.CreateWeapon(weapon);
            return await FindById(weaponId);
        }


        public async Task<List<GetWeaponDto>> DeleteWeapon(Weapon weapon)
        {
            var characterId = weapon.CharacterId;
            await weaponRepo.DeleteWeapon(weapon);
            return await FindByCharacterId(characterId);
        }

        public async Task<List<GetWeaponDto>> FindByCharacterId(int characterId)
        {
            var weapons = await weaponRepo.FindByCharacterId(characterId);
            var weaponsDto = weapons
                .Select(ConvertToDto)
                .ToList();
            return weaponsDto;
        }

        public async Task<GetWeaponDto> FindById(int id)
        {
            var weapon = await weaponRepo.FindById(id);
            var weaponDto = ConvertToDto(weapon);
            return weaponDto;
        }
    }
}