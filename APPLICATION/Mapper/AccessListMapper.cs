using AutoMapper;
using APPLICATION.Dto.AccessList;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AccessListMapper : Profile
{
    public AccessListMapper()
    {
        CreateMap<AccessListDto, AccessList>();
        CreateMap<AccessList, GetAccessListDto>();
    }
}
