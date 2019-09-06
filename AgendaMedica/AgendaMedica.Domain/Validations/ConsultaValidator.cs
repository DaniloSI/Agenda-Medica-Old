using AgendaMedica.Domain.Entities;
using FluentValidation;
using System;

namespace AgendaMedica.Domain.Validations
{
    public class ConsultaValidator : AbstractValidator<Consulta>
    {
        public ConsultaValidator()
        {
            RuleFor(consulta => (consulta.Data + consulta.HoraInicio))
                .Must(dataHora => dataHora >= DateTime.Now)
                .WithMessage("A consulta não pode ser no passado.");
        }
    }
}
