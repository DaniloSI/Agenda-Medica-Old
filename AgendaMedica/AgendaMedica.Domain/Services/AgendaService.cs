using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMedica.Domain.Services
{
    public class AgendaService : Service<Agenda>, IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        public AgendaService(IAgendaRepository agendaRepository)
            : base(agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public override void Add(Agenda agenda)
        {
            agenda.ValidationResult = new AgendaValidator().Validate(agenda);

            if (agenda.ValidationResult.IsValid)
                base.Add(agenda);
        }

        public override void Update(Agenda agenda)
        {
            agenda.ValidationResult = new AgendaValidator().Validate(agenda);

            if (agenda.ValidationResult.IsValid)
                base.Update(agenda);
        }

        public void AddHorarioExcecao(HorarioExcecao horarioExcecao)
        {
            Agenda agenda = GetById(horarioExcecao.AgendaId);

            agenda.HorariosExcecoes.Add(horarioExcecao);
            agenda.ValidationResult = new AgendaValidator().Validate(agenda);

            if (agenda.ValidationResult.IsValid)
            {
                horarioExcecao.ValidationResult = agenda.ValidationResult;
                base.Update(agenda);
            }
        }

        public IEnumerable<Horario> GetHorariosPorDataProfissional(UsuarioProfissional profissional, DateTime data)
        {
            Agenda agenda = profissional?
                .Agendas?
                .SingleOrDefault(a => data >= a.DataHoraInicio && data <= a.DataHoraFim);

            return agenda?
                .Horarios?
                .Where(h => h.DiaSemana == (DiaSemana)data.DayOfWeek);
        }
    }
}
