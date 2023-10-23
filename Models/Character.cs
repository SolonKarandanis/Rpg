namespace rpg.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Frodo";

        public int HitPoints { get; set; } = 100;

        public int Strength { get; set; } = 10;

        public int Defense { get; set; } = 10;

        public int Intelligence { get; set; } = 10;

        public RpgClass Class { get; set; } = RpgClass.Knight;

        public Backpack Backpack { get; set; }

        public List<Weapon> Weapons { get; set; }

        public List<Faction> Factions { get; set; }
    }
}