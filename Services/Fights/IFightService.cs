using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg.Dtos.Fights;

namespace Rpg.Services.Fights
{
    public interface IFightService
    {
         Task<AttackResultDto> WeaponAttack(WeaponAttackDto request);
         Task<AttackResultDto> SkillAttack(SkillAttackDto request);
         Task<FightResultDto> Fight(FightRequestDto request);
         Task<List<HighscoreDto>> GetHighscores();
    }
}