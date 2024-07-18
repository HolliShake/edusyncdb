using AutoMapper;
using APPLICATION.Dto.UserAccess;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class UserAccessMapper : Profile
{
    public UserAccessMapper()
    {
        CreateMap<UserAccessDto, UserAccess>();
        CreateMap<UserAccess, GetUserAccessDto>();
    }
}
