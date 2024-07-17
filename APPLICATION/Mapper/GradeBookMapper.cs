using AutoMapper;
using APPLICATION.Dto.GradeBook;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GradeBookMapper : Profile
{
    public GradeBookMapper()
    {
        CreateMap<GradeBookDto, GradeBook>();
        CreateMap<GradeBook, GetGradeBookDto>();
    }
}
