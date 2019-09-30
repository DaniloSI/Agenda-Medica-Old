using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaMedica.Domain.Entities
{
    public class Agenda
    {
        public int AgendaId { get; set; }
        public string Titulo { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
        public virtual ICollection<HorarioExcecao> HorariosExcecoes { get; set; }
        public int ProfissionalId { get; set; }
        public virtual UsuarioProfissional Profissional { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public Agenda()
        {
            if (Horarios == null)
                Horarios = new List<Horario>();

            if (HorariosExcecoes == null)
                HorariosExcecoes = new List<HorarioExcecao>();
        }
    }
}
