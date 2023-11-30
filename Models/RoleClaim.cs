using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace rpg.Models
{
    public class RoleClaim:IdentityRoleClaim<int>
    {
        public RoleClaim() : base() { }
        public override int RoleId { get; set; }
    }
}