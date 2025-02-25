using AutoMapper;
using Barberia.Core.DTOs.UserDTO;
using Barberia.Core.Entities;

namespace Barberia.Application.Mapper
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<RegistrationDTO, AppUser>().ReverseMap();
        }
    }
}
