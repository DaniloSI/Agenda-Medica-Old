using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AutoMapper;

namespace AgendaMedica.Application.AppServices
{
    public class AgendaAppService : AppService<Agenda, AgendaViewModel>, IAgendaAppService
    {
        private readonly IAgendaService _agendaService;
        public AgendaAppService(IAgendaService agendaService,
            IUnitOfWork UoW,
            IMapper mapper)
            : base(agendaService, UoW, mapper)
        {
            _agendaService = agendaService;
        }

        public override void Add(AgendaViewModel agendaViewModel)
        {
            Agenda agenda = _mapper.Map<Agenda>(agendaViewModel);

            _agendaService.Add(agenda);

            if (agenda.ValidationResult.IsValid)
                UoW.Commit();

            agendaViewModel.ValidationResult = agenda.ValidationResult;
        }
    }
}
