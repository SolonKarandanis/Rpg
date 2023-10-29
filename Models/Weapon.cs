using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace rpg.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WeaponType Type { get; set; } = WeaponType.Sword;
        public int CharacterId { get; set; }

        [JsonIgnore]
         public Character Character { get; set; }
    }
}