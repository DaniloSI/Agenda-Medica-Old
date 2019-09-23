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
                    DataHoraInicio = DateTime.MinValue,
                    DataHoraFim = DateTime.MaxValue
                }
            );

            builder.ToTable(nameof(Agenda));
        }
    }
}
