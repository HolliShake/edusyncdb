using AutoMapper;
using APPLICATION.Dto.ClearanceTag;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ClearanceTagMapper : Profile
{
    public ClearanceTagMapper()
    {
        CreateMap<ClearanceTagDto, ClearanceTag>();
        CreateMap<ClearanceTag, GetClearanceTagDto>();
    }
}
