using AutoMapper;
using APPLICATION.Dto.AccessListAction;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AccessListActionMapper : Profile
{
    public AccessListActionMapper()
    {
        CreateMap<AccessListActionDto, AccessListAction>();
        CreateMap<AccessListAction, GetAccessListActionDto>();
    }
}
