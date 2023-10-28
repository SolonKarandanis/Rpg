using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace rpg.Dtos.Characters
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
        public GetBackpackDto? Backpack { get; set; }
        public List<GetWeaponDto>? Weapons { get; set; }
        public List<GetFactionDto>? Factions { get; set; }
        public List<GetSkillDto>? Skills { get; set; }
        public int CharacterId { get; set; }
    }
}