using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Data.Repositories;

namespace rpg.Data.Repositories.Skills
{
    public class SkillRepository :Repository<Skill>, ISkillRepository,IDisposable
    {
        private readonly DataContext context;

        public SkillRepository(DataContext context):base(context)
        {
            this.context = context;
        }


        public async Task<bool> SkillExistsByName(string name)
        {
            if (await context.Skills
                .AnyAsync(skill => skill.Name.ToLower() == name.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task<int> DeleteByCharacterId(int characterId)
        {
            return await context.Skills
                .Where(w=> w.CharacterId == characterId)
                .ExecuteDeleteAsync();
        }

        public async void Dispose()
        {
            await context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}