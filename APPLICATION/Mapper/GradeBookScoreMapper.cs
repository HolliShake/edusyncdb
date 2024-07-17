using AutoMapper;
using APPLICATION.Dto.GradeBookScore;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GradeBookScoreMapper : Profile
{
    public GradeBookScoreMapper()
    {
        CreateMap<GradeBookScoreDto, GradeBookScore>();
        CreateMap<GradeBookScore, GetGradeBookScoreDto>();
    }
}
