using AgendaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Data.Mappings
{
    public class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(c => c.ConsultaId);

            builder.HasOne(x => x.Paciente)
                .WithMany(x => x.Consultas)
                .HasForeignKey(x => x.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Profissional)
                .WithMany(x => x.Consultas)
                .HasForeignKey(x => x.ProfissionalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Especialidade)
                .WithMany()
                .HasForeignKey(x => x.EspecialidadeId);

            builder.ToTable(nameof(Consulta));
        }
    }
}
