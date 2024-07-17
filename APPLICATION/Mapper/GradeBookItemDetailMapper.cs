using AutoMapper;
using APPLICATION.Dto.GradeBookItemDetail;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GradeBookItemDetailMapper : Profile
{
    public GradeBookItemDetailMapper()
    {
        CreateMap<GradeBookItemDetailDto, GradeBookItemDetail>();
        CreateMap<GradeBookItemDetail, GetGradeBookItemDetailDto>();
    }
}
