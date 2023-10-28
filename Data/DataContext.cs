using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace rpg.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<User> Users => Set<User>();
    }
}