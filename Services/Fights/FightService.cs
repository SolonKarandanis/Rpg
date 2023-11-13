using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg.Dtos.Fights;

namespace Rpg.Services.Fights
{
    public class FightService : IFightService
    {
        private readonly ICharacterRepository characterService;

        public FightService(ICharacterRepository characterService)
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
            var attacker = await characterService.FindById(request.AttackerId,true);
            var opponent = await characterService.FindById(request.OpponentId,false);

            if (attacker is null || opponent is null || attacker.Skills is null)
                    throw new Exception("Something fishy is going on here...");

            var skill = attacker.Skills.FirstOrDefault(s => s.Id == request.SkillId);
            if (skill is null)
                throw new Exception($"{attacker.Name} doesn't know that skill!");

            int damage = DoSkillAttack(attacker, opponent, skill);
            if (opponent.HitPoints <= 0)
                throw new Exception($"{opponent.Name} has been defeated!");

            List<Character> characters = new List<Character>{attacker,opponent};
            await characterService.UpdateRange(characters);

            var result = new AttackResultDto(){
                Attacker = attacker.Name,
                Opponent = opponent.Name,
                AttackerHP = attacker.HitPoints,
                OpponentHP = opponent.HitPoints,
                Damage = damage
            };
            return result;
        }

        public async Task<AttackResultDto> WeaponAttack(WeaponAttackDto request)
        {
            var attacker = await characterService.FindById(request.AttackerId,true);
            var opponent = await characterService.FindById(request.OpponentId,false);

            if (attacker is null || opponent is null || attacker.Skills is null)
                    throw new Exception("Something fishy is going on here...");

            int damage = DoWeaponAttack(attacker, opponent);
            
            if (opponent.HitPoints <= 0)
                throw new Exception($"{opponent.Name} has been defeated!");

            List<Character> characters = new List<Character>{attacker,opponent};
            await characterService.UpdateRange(characters);
            var result = new AttackResultDto(){
                Attacker = attacker.Name,
                Opponent = opponent.Name,
                AttackerHP = attacker.HitPoints,
                OpponentHP = opponent.HitPoints,
                Damage = damage
            };
            return result;
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
            int damage = attacker.Weapons[0].Damage + (new Random().Next(attacker.Strength));
            damage -= new Random().Next(opponent.Defeats);
            if(damage > 0){
                opponent.HitPoints -= damage;
            }
            return damage;
        }
    }
}