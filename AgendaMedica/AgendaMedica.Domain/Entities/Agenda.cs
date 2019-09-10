using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaMedica.Domain.Entities
{
    public class Agenda
    {
        public int AgendaId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
        public int ProfissionalId { get; set; }
        public virtual UsuarioProfissional Profissional { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
    }
}
