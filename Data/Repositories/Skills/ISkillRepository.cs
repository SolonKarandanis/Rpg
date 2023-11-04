using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Data.Repositories.Skills
{
    public interface ISkillRepository
    {
        Task<Skill> FindById(int id);

        Task<List<Skill>> FindAll();

        Task<int> CreateSkill(Skill skill);

        Task<int> UpdateSkill(Skill skill);

        Task<int> DeleteSkill(Skill skill);
    }
}