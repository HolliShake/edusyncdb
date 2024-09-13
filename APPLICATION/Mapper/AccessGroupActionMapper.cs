using AutoMapper;
using APPLICATION.Dto.AccessGroupAction;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AccessGroupActionMapper : Profile
{
    public AccessGroupActionMapper()
    {
        CreateMap<AccessGroupActionDto, AccessGroupAction>();
        CreateMap<AccessGroupAction, GetAccessGroupActionDto>();
    }
}
