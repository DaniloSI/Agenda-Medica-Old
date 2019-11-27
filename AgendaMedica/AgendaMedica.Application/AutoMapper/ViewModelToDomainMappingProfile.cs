using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Entities.ManyToManys;
using AutoMapper;
using System.Linq;

namespace AgendaMedica.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EspecialidadeViewModel, Especialidade>();
            CreateMap<HorarioViewModel, Horario>();
            CreateMap<HorarioExcecaoViewModel, HorarioExcecao>();
            CreateMap<AgendaViewModel, Agenda>();
            CreateMap<ConsultaViewModel, Consulta>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<UsuarioProfissionalViewModel, UsuarioProfissional>()
                .ForMember(dest => dest.Especialidades, opt => opt.MapFrom((src, dest) => src.Especialidades?.Select(esp => new UsuarioProfissionalEspecialidade(dest.Id, esp.EspecialidadeId))));
            CreateMap<UsuarioPacienteViewModel, UsuarioPaciente>();
            CreateMap<UsuarioAdminViewModel, UsuarioAdmin>();
            CreateMap<LoginViewModel, Usuario>();
        }
    }
}
