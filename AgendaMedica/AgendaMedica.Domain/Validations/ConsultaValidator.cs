using AgendaMedica.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMedica.Domain.Validations
{
    public class ConsultaValidator : AbstractValidator<Consulta>
    {
        public static readonly  IReadOnlyDictionary<string, string> ErrorsMessages = new Dictionary<string, string>
        {
            ["CONSULTA_NO_PASSADO"] = "A consulta não pode ser no passado",
            ["CONFLITO_HORARIO_PROFISSIONAL"] = "O profissional {{PROFISSIONAL_NOME}} já possui uma outra consulta agendada para esse horário",
            ["CONFLITO_HORARIO_PACIENTE"] = "Você já possui uma consulta agendada para esse horário",
            ["PROFISSIONAL_OBRIGATORIO"] = "O Profissional é obrigatório",
            ["PACIENTE_OBRIGATORIO"] = "O Paciente é obrigatório",
            ["ESPECIALIDADE_OBRIGATORIA"] = "O campo Especialidade é obrigatório",
            ["HORARIO_INDISPONIVEL"] = "A agenda não possui disponibilidade para esse horário"
        };

        public ConsultaValidator()
        {
            RuleFor(consulta => consulta.EspecialidadeId)
                .Must(especialidadeId => especialidadeId > 0)
                .WithMessage(ErrorsMessages["ESPECIALIDADE_OBRIGATORIA"]);

            RuleFor(consulta => consulta.ProfissionalId)
                .Must(profissionalId => profissionalId > 0)
                .WithMessage(ErrorsMessages["PROFISSIONAL_OBRIGATORIO"]);

            RuleFor(consulta => consulta.PacienteId)
                .Must(pacienteId => pacienteId > 0)
                .WithMessage(ErrorsMessages["PACIENTE_OBRIGATORIO"]);

            RuleFor(consulta => consulta.Profissional.Agendas)
                .Must((consulta, agendas) => agendas.Any(a => consulta.DataHoraInicio >= a.DataHoraInicio && consulta.DataHoraFim <= a.DataHoraFim) &&
                    agendas.Single(a => consulta.DataHoraInicio >= a.DataHoraInicio && consulta.DataHoraFim <= a.DataHoraFim)
                        .Horarios.Any(h => h.DiaSemana == (DiaSemana)consulta.Data.DayOfWeek &&
                            consulta.HoraInicio >= h.HoraInicio &&
                            consulta.HoraFim <= h.HoraFim))
                .WithMessage(ErrorsMessages["HORARIO_INDISPONIVEL"]);

            RuleFor(consulta => consulta.DataHoraInicio)
                .Must(dataHoraInicio => dataHoraInicio >= DateTime.Now)
                .WithMessage(ErrorsMessages["CONSULTA_NO_PASSADO"]);

            RuleFor(novaConsulta => novaConsulta.Profissional)
                .Must((novaConsulta, profissional) => !profissional.ConflitaHorario(novaConsulta))
                .WithMessage(c => ErrorsMessages["CONFLITO_HORARIO_PROFISSIONAL"].Replace("{{PROFISSIONAL_NOME}}", c.Profissional.Nome));

            RuleFor(novaConsulta => novaConsulta.Paciente)
                .Must((novaConsulta, paciente) => !paciente.ConflitaHorario(novaConsulta))
                .WithMessage(ErrorsMessages["CONFLITO_HORARIO_PACIENTE"]);
        }
    }
}
