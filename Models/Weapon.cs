using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace rpg.Models
{
    public class Weapon:IModelIdentifier
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public string Name { get; set; }= string.Empty;

        public int Damage { get; set; }
        public WeaponType Type { get; set; } = WeaponType.Sword;
        public int CharacterId { get; set; }

        [JsonIgnore]
         public Character Character { get; set; }
    }
}