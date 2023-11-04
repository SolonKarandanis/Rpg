using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Services.Skills
{
    public class SkillService : ISkillService
    {
        private readonly IMapper mapper;
        private readonly ISkillRepository skillRepo;

        public SkillService(ISkillRepository skillRepo,IMapper mapper)
        {
            this.mapper = mapper;
            this.skillRepo=skillRepo;
        }

        public async Task<Skill> CreateSkill(Skill skill)
        {
            var exists = skillRepo.SkillExistsByName(skill.Name);
            if(exists is not null){
                throw new Exception($"Skill with Name '{skill.Name}' already exists.");
            }
            var skillId= await skillRepo.CreateSkill(skill);
            return await FindById(skillId);
        }

        public async Task<int> DeleteSkill(int id)
        {
            var existingSkill = await FindById(id);
            
            return await skillRepo.DeleteSkill(existingSkill);
        }

        public async Task<List<Skill>> FindAll()
        {
            return await skillRepo.FindAll();
        }

        public async Task<Skill> FindById(int id)
        {
            var skill = await skillRepo.FindById(id);
            if(skill is null){
                throw new Exception($"Skill with Id '{id}' not found.");
            }
            return skill;
        }

        public async Task<Skill> UpdateSkill(Skill skill)
        {
            var skillId = skill.Id;
            var existingSkill = await FindById(skillId);

            var exists = skillRepo.SkillExistsByName(skill.Name);
            if(exists is not null){
                throw new Exception($"Skill with Name '{skill.Name}' already exists.");
            }

            existingSkill.Name = skill.Name;
            existingSkill.Damage = skill.Damage;

            await skillRepo.UpdateSkill(existingSkill);
            return existingSkill;
        }
    }
}