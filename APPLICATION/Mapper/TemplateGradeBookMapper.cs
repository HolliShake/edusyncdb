using AutoMapper;
using APPLICATION.Dto.TemplateGradeBook;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class TemplateGradeBookMapper : Profile
{
    public TemplateGradeBookMapper()
    {
        CreateMap<TemplateGradeBookDto, TemplateGradeBook>();
        CreateMap<TemplateGradeBook, GetTemplateGradeBookDto>();
    }
}
