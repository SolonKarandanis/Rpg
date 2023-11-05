using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Services.Skills
{
    public interface ISkillService
    {
        Task<Skill> CreateSkill(Skill skill);

        Task<int> DeleteSkill(int id);

        Task<IEnumerable<Skill>> FindAll();

        Task<Skill> FindById(int id);

        Task<Skill> UpdateSkill(Skill skill);
    }
}