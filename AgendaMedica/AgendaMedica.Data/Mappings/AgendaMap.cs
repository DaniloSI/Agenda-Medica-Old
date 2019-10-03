using AgendaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgendaMedica.Data.Mappings
{
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(c => c.AgendaId);

            builder.HasOne(a => a.Profissional)
                .WithMany(p => p.Agendas)
                .HasForeignKey(a => a.ProfissionalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Agenda
                {
                    AgendaId = 1,
                    ProfissionalId = 3,
                    DataHoraInicio = new DateTime(1899, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    DataHoraFim = new DateTime(2099, 12, 31, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            builder.ToTable(nameof(Agenda));
        }
    }
}
