using AgendaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Data.Mappings
{
    public class EspecialidadeMap : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.HasKey(c => c.EspecialidadeId);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Codigo)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.ToTable(nameof(Especialidade));

            builder.HasData(
                new Especialidade
                {
                    EspecialidadeId = 1,
                    Codigo = "ANSTSLG",
                    Nome = "Anestesiologia"
                },
                new Especialidade
                {
                    EspecialidadeId = 2,
                    Codigo = "CIRUR. PLAST.",
                    Nome = "Cirurgia Plástica"
                },
                new Especialidade
                {
                    EspecialidadeId = 3,
                    Codigo = "MED. ESP.",
                    Nome = "Medicina Esportiva"
                },
                new Especialidade
                {
                    EspecialidadeId = 4,
                    Codigo = "ORTOP. E TRAUM.",
                    Nome = "Ortopedia e Traumatologia"
                }
            );
        }
    }
}
