
using AutoMapper;
using DOMAIN.Model;
using APPLICATION.Dto.AccessGroup;

namespace APPLICATION.Mapper;

public class AccessGroupMapper : Profile
{
    public AccessGroupMapper()
    {
        CreateMap<AccessGroupDto, AccessGroup>();
        CreateMap<AccessGroup, GetAccessGroupDto>();
    }
}