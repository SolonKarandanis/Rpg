using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Dtos.Fights
{
    public class FightRequestDto
    {
        public List<int> CharacterIds { get; set; } = new List<int>();
    }
}