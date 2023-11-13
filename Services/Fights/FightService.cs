using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg.Dtos.Fights;

namespace Rpg.Services.Fights
{
    public class FightService : IFightService
    {
        private readonly ICharacterService characterService;

        public FightService(CharacterService characterService)
        {
            this.characterService=characterService;
        }
        public async Task<FightResultDto> Fight(FightRequestDto request)
        {
            var result = new FightResultDto();
            var characters = await characterService.FindByIdsWithWeaponsAndSkills(request.CharacterIds);
            bool defeated = false;

            while (!defeated){
                foreach(var attacker in characters){
                    var opponents = characters.Where(c => c.Id != attacker.Id).ToList();
                    var opponent = opponents[new Random().Next(opponents.Count)];

                    int damage = 0;
                    string attackUsed = string.Empty;

                    bool useWeapon = new Random().Next(2) == 0;
                    if (useWeapon && attacker.Weapons is not null)
                    {
                        damage = DoWeaponAttack(attacker, opponent);
                    }
                    else if (!useWeapon && attacker.Skills is not null)
                    {
                        var skill = attacker.Skills[new Random().Next(attacker.Skills.Count)];
                        attackUsed = skill.Name;
                        damage = DoSkillAttack(attacker, opponent, skill);
                    }
                    else
                    {
                        result.Log
                            .Add($"{attacker.Name} wasn't able to attack!");
                        continue;
                    }
                        result.Log
                            .Add($"{attacker.Name} attacks {opponent.Name} using {attackUsed} with {(damage >= 0 ? damage : 0)} damage");

                    if (opponent.HitPoints <= 0)
                    {
                        defeated = true;
                        attacker.Victories++;
                        opponent.Defeats++;
                        result.Log.Add($"{opponent.Name} has been defeated!");
                        result.Log.Add($"{attacker.Name} wins with {attacker.HitPoints} HP left!");
                        break;
                    }
                }
            }

            characters.ForEach(c =>
            {
                c.Fights++;
                c.HitPoints = 100;
            });

            await characterService.UpdateRange(characters);
            return result;
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