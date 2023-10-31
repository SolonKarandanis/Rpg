using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace rpg.Models
{
    public class Faction
    {
        public int Id { get; set; }
        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public string Name { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}