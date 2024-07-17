using AutoMapper;
using APPLICATION.Dto.GradeBookItem;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GradeBookItemMapper : Profile
{
    public GradeBookItemMapper()
    {
        CreateMap<GradeBookItemDto, GradeBookItem>();
        CreateMap<GradeBookItem, GetGradeBookItemDto>();
    }
}
