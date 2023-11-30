using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace rpg.Models
{
    public class UserRole: IdentityUserRole<int>
    {
        public UserRole() : base() { }

        public override int RoleId { get; set; }
        public override int UserId { get; set; }
    }
}