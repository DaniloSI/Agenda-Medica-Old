using AgendaMedica.API.DTO;
using AgendaMedica.Domain.Identity;
using AutoMapper;

namespace AgendaMedica.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, AppUserDTO>()
                .ReverseMap();

            CreateMap<AppUser, AppUserLoginDTO>()
                .ReverseMap();
        }
    }
}
