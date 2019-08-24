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
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();

            CreateMap<UsuarioProfissional, UsuarioProfissionalDTO>()
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();

            CreateMap<AppUser, AppUserLoginDTO>()
                .ReverseMap();
        }
    }
}
