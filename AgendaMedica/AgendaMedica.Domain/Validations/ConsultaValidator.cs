using AgendaMedica.Domain.Entities;
using FluentValidation;
using System;
using System.Linq;

namespace AgendaMedica.Domain.Validations
{
    public class ConsultaValidator : AbstractValidator<Consulta>
    {
        public ConsultaValidator()
        {
            RuleFor(consulta => consulta.DataHoraInicio)
                .Must(dataHoraInicio => dataHoraInicio >= DateTime.Now)
                .WithMessage("A consulta não pode ser no passado.");

            RuleFor(novaConsulta => novaConsulta.Profissional)
                .Must((novaConsulta, profissional) => !profissional.ConflitaHorario(novaConsulta))
                .WithMessage(c => "O profissional " + c.Profissional.Nome + " já possui uma outra consulta agendada para esse horário.");
        }
    }
}
