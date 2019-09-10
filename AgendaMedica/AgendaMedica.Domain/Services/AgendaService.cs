using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Validations;

namespace AgendaMedica.Domain.Services
{
    public class AgendaService : Service<Agenda>, IAgendaService
    {
        public AgendaService(IAgendaRepository agendaRepository)
            : base(agendaRepository)
        {
        }

        public override void Add(Agenda agenda)
        {
            agenda.ValidationResult = new AgendaValidator().Validate(agenda);

            if (agenda.ValidationResult.IsValid)
                base.Add(agenda);
        }
    }
}
