﻿using AgendaMedica.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace AgendaMedica.Domain.Validations
{
    public class AgendaValidator : AbstractValidator<Agenda>
    {
        public static readonly IReadOnlyDictionary<string, string> ErrorsMessages = new Dictionary<string, string>
        {
            ["DATA_FIM_MAIOR_QUE_DATA_INICIO"] = "A data final deve ser maior que a data inicial",
            ["HORARIOS_CONFLITAM"] = "Existe conflito de horários",
        };

        public AgendaValidator()
        {
            RuleFor(agenda => agenda)
                .Must(agenda => agenda.DataHoraFim > agenda.DataHoraInicio)
                .WithMessage(ErrorsMessages["DATA_FIM_MAIOR_QUE_DATA_INICIO"]);

            RuleFor(agenda => agenda.Horarios)
                .Must(horarios => !horarios.Any(horarioX => horarios.Any(horarioY => horarioX != horarioY && horarioX.Conflita(horarioY))))
                .WithMessage(ErrorsMessages["HORARIOS_CONFLITAM"]);
        }
    }
}
