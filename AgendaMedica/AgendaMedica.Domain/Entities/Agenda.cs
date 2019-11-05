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
        public decimal? PrecoConsulta { get; set; }
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

        public bool ConflitaPeriodoVigencia(Agenda a)
        {
            bool dataInicioConflita = DataHoraInicio >= a.DataHoraInicio && DataHoraInicio < a.DataHoraFim;
            bool dataFimConflita = DataHoraFim > a.DataHoraInicio && DataHoraFim <= a.DataHoraFim;
            dataInicioConflita = dataInicioConflita || a.DataHoraInicio >= DataHoraInicio && a.DataHoraInicio < DataHoraFim;
            dataFimConflita = dataFimConflita || a.DataHoraFim > DataHoraInicio && a.DataHoraFim <= DataHoraFim;

            return dataInicioConflita || dataFimConflita;
        }
    }
}
