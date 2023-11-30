using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace rpg.Models
{
    public class Role: IdentityRole<int>
    {
        public Role() : base() { }
        public override int Id { get; set; }
        public virtual string Description { get; set; }

    }
}