using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaMedica.Domain.Entities
{
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public bool PagamentoConfirmado { get; set; }
        public int PacienteId { get; set; }
        public virtual UsuarioPaciente Paciente { get; set; }
        public int ProfissionalId { get; set; }
        public virtual UsuarioProfissional Profissional { get; set; }
        public int EspecialidadeId { get; set; }
        public virtual Especialidade Especialidade { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public DateTime DataHoraInicio
        {
            get
            {
                return Data + HoraInicio;
            }
        }

        public DateTime DataHoraFim
        {
            get
            {
                return Data + HoraFim;
            }
        }
    }
}
