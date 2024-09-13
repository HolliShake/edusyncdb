using AutoMapper;
using APPLICATION.Dto.UserAccessGroupDetails;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class UserAccessGroupDetailsMapper : Profile
{
    public UserAccessGroupDetailsMapper()
    {
        CreateMap<UserAccessGroupDetailsDto, UserAccessGroupDetails>();
        CreateMap<UserAccessGroupDetails, GetUserAccessGroupDetailsDto>();
    }
}
