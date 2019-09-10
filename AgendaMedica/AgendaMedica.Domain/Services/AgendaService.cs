using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Validations;

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

        public void AddHorarioExcecao(HorarioExcecao horarioExcecao)
        {
            Agenda agenda = GetById(horarioExcecao.AgendaId);

            agenda.HorariosExcecoes.Add(horarioExcecao);
            agenda.ValidationResult = new AgendaValidator().Validate(agenda);

            if (agenda.ValidationResult.IsValid)
            {
                horarioExcecao.ValidationResult = agenda.ValidationResult;
                base.Update(agenda); //_agendaRepository.AddHorarioExcecao(horarioExcecao);
            }
        }
    }
}
