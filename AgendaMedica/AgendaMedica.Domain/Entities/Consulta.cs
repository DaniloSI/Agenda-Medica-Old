using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaMedica.Domain.Entities
{
    public enum TipoPagamento
    {
        Dinheiro = 1,
        Boleto,
        Credito
    }

    public enum ConsultaEstado
    {
        Agendada = 0,
        Realizada,
        Cancelada
    }

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
        public ConsultaEstado Estado { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public DateTime? DataRealizacaoPagamento { get; set; }

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

        public bool ConflitaHorario(Consulta consulta)
        {
            bool conflitaHorarioInicio = consulta.DataHoraInicio > DataHoraInicio && consulta.DataHoraInicio < DataHoraFim;
            bool conflitaHorarioFim = consulta.DataHoraFim > DataHoraInicio && consulta.DataHoraFim < DataHoraFim;

            conflitaHorarioInicio = conflitaHorarioInicio || (DataHoraInicio > consulta.DataHoraInicio && DataHoraInicio < consulta.DataHoraFim);
            conflitaHorarioFim = conflitaHorarioFim || (DataHoraFim > consulta.DataHoraInicio && DataHoraFim < consulta.DataHoraFim);

            return Estado == ConsultaEstado.Agendada && (conflitaHorarioInicio || conflitaHorarioFim || (DataHoraInicio == consulta.DataHoraInicio && DataHoraFim == consulta.DataHoraFim));
        }
    }
}
