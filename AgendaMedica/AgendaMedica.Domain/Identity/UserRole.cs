using Microsoft.AspNetCore.Identity;

namespace AgendaMedica.Domain.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public Role Role { get; set; }
    }
}
