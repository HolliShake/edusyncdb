using AutoMapper;
using APPLICATION.Dto.TemplateGradeBookItem;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class TemplateGradeBookItemMapper : Profile
{
    public TemplateGradeBookItemMapper()
    {
        CreateMap<TemplateGradeBookItemDto, TemplateGradeBookItem>();
        CreateMap<TemplateGradeBookItem, GetTemplateGradeBookItemDto>();
    }
}
