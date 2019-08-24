using AgendaMedica.API.DTO;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Identity;
using AutoMapper;

namespace AgendaMedica.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UsuarioPaciente, UsuarioPacienteDTO>()
                .ReverseMap();

            CreateMap<UsuarioProfissional, UsuarioProfissionalDTO>()
                .ReverseMap();

            CreateMap<AppUser, AppUserLoginDTO>()
                .ReverseMap();
        }
    }
}
