using AgendaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

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
                .OnDelete(DeleteBehavior.Cascade);

            List<Horario> horarios = new List<Horario>();
            int horarioId = 1;
            foreach (DiaSemana diaSemana in Enum.GetValues(typeof(DiaSemana)))
            {
                foreach (int hora in Enumerable.Range(7, 7))
                {
                    horarios.Add(new Horario
                    {
                        HorarioId = horarioId++,
                        AgendaId = 1,
                        DiaSemana = diaSemana,
                        HoraInicio = new TimeSpan(hora, 30, 0),
                        HoraFim = new TimeSpan(hora + 1, 30, 0)
                    });
                }
            }
            builder.HasData(horarios);

            builder.ToTable(nameof(Horario));
        }
    }
}
