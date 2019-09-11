using AgendaMedica.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace AgendaMedica.Domain.Validations
{
    public class ConsultaValidator : AbstractValidator<Consulta>
    {
        public static readonly  IReadOnlyDictionary<string, string> ErrorsMessages = new Dictionary<string, string>
        {
            ["CONSULTA_NO_PASSADO"] = "A consulta não pode ser no passado",
            ["CONFLITO_HORARIO_PROFISSIONAL"] = "O profissional {{PROFISSIONAL_NOME}} já possui uma outra consulta agendada para esse horário."
        };

        public ConsultaValidator()
        {
            RuleFor(consulta => consulta.DataHoraInicio)
                .Must(dataHoraInicio => dataHoraInicio >= DateTime.Now)
                .WithMessage(ErrorsMessages["CONSULTA_NO_PASSADO"]);

            RuleFor(novaConsulta => novaConsulta.Profissional)
                .Must((novaConsulta, profissional) => !profissional.ConflitaHorario(novaConsulta))
                .WithMessage(c => ErrorsMessages["CONFLITO_HORARIO_PROFISSIONAL"].Replace("{{PROFISSIONAL_NOME}}", c.Profissional.Nome));
        }
    }
}
