using AutoMapper;
using APPLICATION.Dto.SpecializationChair;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SpecializationChairMapper : Profile
{
    public SpecializationChairMapper()
    {
        CreateMap<SpecializationChairDto, SpecializationChair>();
        CreateMap<SpecializationChair, GetSpecializationChairDto>();
    }
}
