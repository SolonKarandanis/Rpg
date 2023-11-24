using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Data.Repositories;

namespace rpg.Data.Repositories.Skills
{
    public interface ISkillRepository:IRepository<Skill>
    {
        Task<bool> SkillExistsByName(string name);

        Task<int> DeleteByCharacterId(int characterId);
    }
}