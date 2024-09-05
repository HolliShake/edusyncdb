using AutoMapper;
using APPLICATION.Dto.UserCampusDetails;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class UserCampusDetailsMapper : Profile
{
    public UserCampusDetailsMapper()
    {
        CreateMap<UserCampusDetailsDto, UserCampusDetails>();
        CreateMap<UserCampusDetails, GetUserCampusDetailsDto>();
    }
}
