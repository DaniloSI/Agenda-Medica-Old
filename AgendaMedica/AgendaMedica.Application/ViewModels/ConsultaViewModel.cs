using AgendaMedica.Domain.Entities;
using FluentValidation.Results;
using System;

namespace AgendaMedica.Application.ViewModels
{
    public class ConsultaViewModel
    {
        public int ConsultaId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public bool PagamentoConfirmado { get; set; }
        public int PacienteId { get; set; }
        public UsuarioPacienteViewModel Paciente { get; set; }
        public int ProfissionalId { get; set; }
        public UsuarioProfissionalViewModel Profissional { get; set; }
        public int EspecialidadeId { get; set; }
        public EspecialidadeViewModel Especialidade { get; set; }
        public ConsultaEstado Estado { get; set; }
        public TipoPagamento? TipoPagamento { get; set; }
        public DateTime? DataRealizacaoPagamento { get; set; }
        public CartaoViewModel Cartao { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}
