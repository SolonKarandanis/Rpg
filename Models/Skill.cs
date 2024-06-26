using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Models
{
    public class Skill:IModelIdentifier
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public int CharacterId { get; set; }
        public List<Character>? Characters { get; set; }
    }
}