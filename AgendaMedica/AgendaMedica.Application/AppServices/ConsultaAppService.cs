using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AutoMapper;

namespace AgendaMedica.Application.AppServices
{
    public class ConsultaAppService : AppService<Consulta, ConsultaViewModel>, IConsultaAppService
    {
        private readonly IConsultaService _consultaService;
        public ConsultaAppService(IConsultaService consultaService,
            IUnitOfWork UoW,
            IMapper mapper)
            : base(consultaService, UoW, mapper)
        {
            _consultaService = consultaService;
        }

        public override void Add(ConsultaViewModel consultaViewModel)
        {
            Consulta consulta = _mapper.Map<Consulta>(consultaViewModel);

            _consultaService.Add(consulta);

            if (consulta.ValidationResult.IsValid)
                UoW.Commit();

            consultaViewModel.ValidationResult = consulta.ValidationResult;
        }
    }
}
