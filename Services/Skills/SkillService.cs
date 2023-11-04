using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Services.Skills
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository skillRepo;

        public SkillService(ISkillRepository skillRepo)
        {
            this.skillRepo=skillRepo;
        }

        public Task<Skill> CreateSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteSkill(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Skill>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Skill> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Skill> UpdateSkill(Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}