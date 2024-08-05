using AutoMapper;
using Solway.DTO;
using Solway.Models;

namespace Solway.Helpers;

public class MappingProfilesHelper : Profile
{
    public MappingProfilesHelper()
    {
        CreateMap<AppUser, AppUserDTO>().ReverseMap();
        CreateMap<AppUser, RegisterUserDTO>().ReverseMap();
        CreateMap<Content, ContentDTO>().ReverseMap();
        CreateMap<MediaType, MediaTypeDTO>().ReverseMap();
    }
}