using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Entities.ManyToManys;
using AutoMapper;
using System.Linq;

namespace AgendaMedica.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Especialidade, EspecialidadeViewModel>();
            CreateMap<Horario, HorarioViewModel>();
            CreateMap<HorarioExcecao, HorarioExcecaoViewModel>();
            CreateMap<Agenda, AgendaViewModel>();
            CreateMap<Consulta, ConsultaViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<UsuarioProfissional, UsuarioProfissionalViewModel>();
            CreateMap<UsuarioProfissionalEspecialidade, EspecialidadeViewModel>()
                .ForMember(dest => dest.EspecialidadeId, opt => opt.MapFrom(x => x.EspecialidadeId))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(x => x.Especialidade.Codigo))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Especialidade.Nome));
            CreateMap<UsuarioPaciente, UsuarioPacienteViewModel>();
            CreateMap<UsuarioAdmin, UsuarioAdminViewModel>();
        }
    }
}
