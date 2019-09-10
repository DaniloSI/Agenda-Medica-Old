using AgendaMedica.Data.Mappings;
using AgendaMedica.Data.Mappings.ManyToManys;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AgendaMedica.Data
{
    public class AgendaMedicaDbContext
        : IdentityDbContext<AppUser, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Horario> Horarios { get; set; }

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

            builder.Entity<UsuarioPaciente>()
                .HasData(
                    new UsuarioPaciente
                    {
                        Id = 1,
                        Nome = "Vanessa",
                        SobreNome = "Bianca da Cruz",
                        DataNascimento = new DateTime(1941, 07, 24),
                        Cpf = "71985694719",
                        Email = "vanessa@teste.com",
                        NormalizedEmail = "VANESSA@TESTE.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==",
                        SecurityStamp = "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C",
                        ConcurrencyStamp = "d7d50895-1e1c-4582-8bd1-6badd9daea7e",
                        LockoutEnabled = true,
                        UserName = "vanessa@teste.com",
                        NormalizedUserName = "VANESSA@TESTE.COM",
                        PhoneNumber = "994839210",
                        EnderecoId = 1
                    },
                    new UsuarioPaciente
                    {
                        Id = 2,
                        Nome = "Victor",
                        SobreNome = "Nelson Martin Caldeira",
                        DataNascimento = new DateTime(1946, 05, 01),
                        Cpf = "52435366442",
                        Email = "victor@teste.com",
                        NormalizedEmail = "VICTOR@TESTE.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==",
                        SecurityStamp = "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C",
                        ConcurrencyStamp = "d7d50895-1e1c-4582-8bd1-6badd9daea7e",
                        LockoutEnabled = true,
                        UserName = "victor@teste.com",
                        NormalizedUserName = "VICTOR@TESTE.COM",
                        PhoneNumber = "997965652",
                        EnderecoId = 2
                    }
                );

            builder.Entity<UsuarioProfissional>()
                .HasData(
                    new UsuarioProfissional
                    {
                        Id = 3,
                        Nome = "Rodrigo",
                        SobreNome = "Vitor Kevin Ferreira",
                        DataNascimento = new DateTime(1971, 03, 04),
                        Cnpj = "63.029.660/0001-15",
                        Email = "rodrigo@teste.com",
                        NormalizedEmail = "RODRIGO@TESTE.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==",
                        SecurityStamp = "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C",
                        ConcurrencyStamp = "d7d50895-1e1c-4582-8bd1-6badd9daea7e",
                        LockoutEnabled = true,
                        UserName = "rodrigo@teste.com",
                        NormalizedUserName = "RODRIGO@TESTE.COM",
                        PhoneNumber = "99349-5462",
                        EnderecoId = 3
                    },
                    new UsuarioProfissional
                    {
                        Id = 4,
                        Nome = "Augusto",
                        SobreNome = "Menezes da Costa",
                        DataNascimento = new DateTime(1982, 07, 01),
                        Cnpj = "35.172.039/0001-70",
                        Email = "augusto@teste.com",
                        NormalizedEmail = "AUGUSTO@TESTE.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==",
                        SecurityStamp = "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C",
                        ConcurrencyStamp = "d7d50895-1e1c-4582-8bd1-6badd9daea7e",
                        LockoutEnabled = true,
                        UserName = "augusto@teste.com",
                        NormalizedUserName = "AUGUSTO@TESTE.COM",
                        PhoneNumber = "99598-2285",
                        EnderecoId = 4
                    }
                );

            var builderEndereco = builder.Entity<Endereco>();
            builderEndereco.HasKey(e => e.EnderecoId);
            builderEndereco.HasData(
                new Endereco
                {
                    EnderecoId = 1,
                    CEP = "29050-902",
                    Cidade = "Vitória",
                    Complemento = "Casa",
                    Estado = "ES",
                    Numero = 56,
                    Rua = "Av. Américo Buaiz"
                },
                new Endereco
                {
                    EnderecoId = 2,
                    CEP = "29045-250",
                    Cidade = "Vitória",
                    Complemento = "Casa",
                    Estado = "ES",
                    Numero = 51,
                    Rua = "Juiz Alexandre Martins de Castro Filho"
                },
                new Endereco
                {
                    EnderecoId = 3,
                    CEP = "29100-000",
                    Cidade = "Vila Velha",
                    Complemento = "Casa",
                    Estado = "ES",
                    Numero = 851,
                    Rua = "Av. São Paulo"
                },
                new Endereco
                {
                    EnderecoId = 4,
                    CEP = "29166-820",
                    Cidade = "Serra",
                    Complemento = "Casa",
                    Estado = "ES",
                    Numero = 711,
                    Rua = "Av. Copacabana"
                }
            );

            builder.ApplyConfiguration(new EspecialidadeMap());
            builder.ApplyConfiguration(new UsuarioProfissionalEspecialidadeMap());
            builder.ApplyConfiguration(new ConsultaMap());
            builder.ApplyConfiguration(new HorarioMap());
            builder.ApplyConfiguration(new AgendaMap());
        }
    }
}
