using AgendaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Data.Mappings
{
    public class HorarioMap : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            builder.HasKey(c => c.HorarioId);

            builder.HasOne(h => h.Agenda)
                .WithMany(a => a.Horarios)
                .HasForeignKey(h => h.AgendaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(nameof(Horario));
        }
    }
}
