using AgendaMedica.Data.Mappings;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Data
{
    public class AgendaMedicaDbContext
        : IdentityDbContext<AppUser, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }

        public AgendaMedicaDbContext(DbContextOptions<AgendaMedicaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<UsuarioPaciente>();
            builder.Entity<UsuarioProfissional>();

            builder.ApplyConfiguration(new EspecialidadeMap());
        }
    }
}
