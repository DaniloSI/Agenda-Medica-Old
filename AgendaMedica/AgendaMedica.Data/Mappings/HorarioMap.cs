using AgendaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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

            builder.HasData(
                new Horario
                {
                    HorarioId = 1,
                    AgendaId = 1,
                    DiaSemana = DiaSemana.Segunda,
                    HoraInicio = new TimeSpan(7, 30, 0),
                    HoraFim = new TimeSpan(8, 30, 0)
                },
                new Horario
                {
                    HorarioId = 2,
                    AgendaId = 1,
                    DiaSemana = DiaSemana.Segunda,
                    HoraInicio = new TimeSpan(8, 30, 0),
                    HoraFim = new TimeSpan(9, 30, 0)
                },
                new Horario
                {
                    HorarioId = 3,
                    AgendaId = 1,
                    DiaSemana = DiaSemana.Segunda,
                    HoraInicio = new TimeSpan(9, 30, 0),
                    HoraFim = new TimeSpan(10, 30, 0)
                },
                new Horario
                {
                    HorarioId = 4,
                    AgendaId = 1,
                    DiaSemana = DiaSemana.Terca,
                    HoraInicio = new TimeSpan(7, 30, 0),
                    HoraFim = new TimeSpan(8, 30, 0)
                },
                new Horario
                {
                    HorarioId = 5,
                    AgendaId = 1,
                    DiaSemana = DiaSemana.Terca,
                    HoraInicio = new TimeSpan(8, 30, 0),
                    HoraFim = new TimeSpan(9, 30, 0)
                },
                new Horario
                {
                    HorarioId = 6,
                    AgendaId = 1,
                    DiaSemana = DiaSemana.Quarta,
                    HoraInicio = new TimeSpan(9, 30, 0),
                    HoraFim = new TimeSpan(10, 30, 0)
                }
            );

            builder.ToTable(nameof(Horario));
        }
    }
}
