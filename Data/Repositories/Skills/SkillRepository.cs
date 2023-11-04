using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Data.Repositories.Skills
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext context;

        public SkillRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateSkill(Skill skill)
        {
            context.Skills.Add(skill);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteSkill(Skill skill)
        {
            context.Skills.Remove(skill);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Skill>> FindAll()
        {
            return await context.Skills.ToListAsync();
        }

        public async Task<Skill> FindById(int id)
        {
            return await context.Skills.FindAsync(id);
        }

        public async Task<int> UpdateSkill(Skill skill)
        {
            context.Skills.Update(skill);
            return await context.SaveChangesAsync();
        }
    }
}