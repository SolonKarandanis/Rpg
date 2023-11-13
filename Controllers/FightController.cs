using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rpg.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService fightService;

        public FightController(IFightService fightService)
        {
            this.fightService = fightService;
        }

        [HttpPost("Weapon")]
        public async Task<ActionResult<AttackResultDto>> WeaponAttack(WeaponAttackDto request)
        {
            return Ok(await fightService.WeaponAttack(request));
        }

        [HttpPost("Skill")]
        public async Task<ActionResult<AttackResultDto>> SkillAttack(SkillAttackDto request)
        {
            return Ok(await fightService.SkillAttack(request));
        }

        [HttpPost]
        public async Task<ActionResult<FightResultDto>> Fight(FightRequestDto request)
        {
            return Ok(await fightService.Fight(request));
        }

        [HttpGet]
        public async Task<ActionResult<List<HighscoreDto>>> GetHighscores()
        {
            return Ok(await fightService.GetHighscores());
        }
    }
}