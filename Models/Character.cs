using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rpg.Models
{
    public class Character
    {
        public int Id { get; set; }

        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public string Name { get; set; } = "Frodo";

        public int HitPoints { get; set; } = 100;

        public int Strength { get; set; } = 10;

        public int Defense { get; set; } = 10;

        public int Intelligence { get; set; } = 10;

        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }

        public RpgClass Class { get; set; } = RpgClass.Knight;

        public Backpack? Backpack { get; set; }

        public List<Weapon>? Weapons { get; set; }

        public List<Faction>? Factions { get; set; }

        public List<Skill>? Skills { get; set; }

        public User? User { get; set; }
    }
}