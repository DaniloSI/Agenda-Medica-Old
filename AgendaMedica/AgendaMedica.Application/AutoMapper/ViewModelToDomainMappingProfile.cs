using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using AutoMapper;

namespace AgendaMedica.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EspecialidadeViewModel, Especialidade>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<UsuarioProfissionalViewModel, UsuarioProfissional>();
            CreateMap<UsuarioPacienteViewModel, UsuarioPaciente>();
            CreateMap<LoginViewModel, Usuario>();
        }
    }
}
