using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TaxComputationAPI.Models
{
    public class User: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}