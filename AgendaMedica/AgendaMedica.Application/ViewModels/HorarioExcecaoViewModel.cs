using FluentValidation.Results;
using System;

namespace AgendaMedica.Application.ViewModels
{
    public class HorarioExcecaoViewModel
    {
        public int HorarioExcecaoId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public bool Atende { get; set; }
        public int AgendaId { get; set; }
        public AgendaViewModel Agenda { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
