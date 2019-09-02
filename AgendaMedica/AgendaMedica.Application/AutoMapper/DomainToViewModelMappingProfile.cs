using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using AutoMapper;

namespace AgendaMedica.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Especialidade, EspecialidadeViewModel>();
        }
    }
}
