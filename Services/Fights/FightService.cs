using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg.Dtos.Fights;

namespace Rpg.Services.Fights
{
    public class FightService : IFightService
    {

        public FightService()
        {
            
        }
        public async Task<FightResultDto> Fight(FightRequestDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HighscoreDto>> GetHighscores()
        {
            throw new NotImplementedException();
        }

        public async Task<AttackResultDto> SkillAttack(SkillAttackDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<AttackResultDto> WeaponAttack(WeaponAttackDto request)
        {
            throw new NotImplementedException();
        }

        private static int DoSkillAttack(Character attacker,Character opponent, Skill skill){
            int damage = skill.Damage + (new Random().Next(attacker.Intelligence));
            damage -= new Random().Next(opponent.Defeats);
            if(damage > 0){
                opponent.HitPoints -= damage;
            }
            return damage;
        }

        private static int DoWeaponAttack(Character attacker, Character opponent){
            if(ListUtils.IsEmpty(attacker.Weapons)){
                throw new Exception("Attacker has no weapons");
            }

            return 0;
        }
    }
}