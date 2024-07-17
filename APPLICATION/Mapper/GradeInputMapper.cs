using AutoMapper;
using APPLICATION.Dto.GradeInput;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GradeInputMapper : Profile
{
    public GradeInputMapper()
    {
        CreateMap<GradeInputDto, GradeInput>();
        CreateMap<GradeInput, GetGradeInputDto>();
    }
}
