using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AutoMapper;

namespace AgendaMedica.Application.AppServices
{
    public class EspecialidadeAppService : AppService<Especialidade, EspecialidadeViewModel>, IEspecialidadeAppService
    {
        private readonly IEspecialidadeService _especialidadeService;
        public EspecialidadeAppService(IEspecialidadeService especialidadeService,
            IUnitOfWork UoW,
            IMapper mapper)
            : base(especialidadeService, UoW, mapper)
        {
            _especialidadeService = especialidadeService;
        }

        public override void Add(EspecialidadeViewModel especialidadeViewModel)
        {
            Especialidade especialidade = _mapper.Map<Especialidade>(especialidadeViewModel);

            _especialidadeService.Add(especialidade);

            if (especialidade.ValidationResult.IsValid)
                UoW.Commit();

            especialidadeViewModel.ValidationResult = especialidade.ValidationResult;
        }

        public override void Update(EspecialidadeViewModel especialidadeViewModel)
        {
            Especialidade especialidade = _mapper.Map<Especialidade>(especialidadeViewModel);

            _especialidadeService.Update(especialidade);

            if (especialidade.ValidationResult.IsValid)
                UoW.Commit();

            especialidadeViewModel.ValidationResult = especialidade.ValidationResult;
        }
    }
}
