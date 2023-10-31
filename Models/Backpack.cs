using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace rpg.Models
{
    public class Backpack
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public string Description { get; set; }
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character Character { get; set; }
    }
}