using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace rpg.Models
{
    public class User:IdentityUser<int>,IModelIdentifier
    {
        [Key]
        public override int Id { get; set; }
        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public override string UserName { get; set; } = string.Empty;
        public  byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public string FirstName { get; set; }= string.Empty;
        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public string LastName { get; set; }= string.Empty;
        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public override  string Email { get; set; }= string.Empty;
        public List<Character>? Characters { get; set; }
    }
}