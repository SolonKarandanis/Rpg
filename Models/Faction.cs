using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace rpg.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}