using AgendaMedica.Domain.Entities;
using System;

namespace AgendaMedica.Application.ViewModels
{
    public class HorarioViewModel
    {
        public int HorarioId { get; set; }
        public DiaSemana DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public int AgendaId { get; set; }
        public AgendaViewModel Agenda { get; set; }
    }
}
