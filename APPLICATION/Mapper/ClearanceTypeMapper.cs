using AutoMapper;
using APPLICATION.Dto.ClearanceType;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ClearanceTypeMapper : Profile
{
    public ClearanceTypeMapper()
    {
        CreateMap<ClearanceTypeDto, ClearanceType>();
        CreateMap<ClearanceType, GetClearanceTypeDto>();
    }
}
