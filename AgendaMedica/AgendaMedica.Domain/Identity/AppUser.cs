using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AgendaMedica.Domain.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
