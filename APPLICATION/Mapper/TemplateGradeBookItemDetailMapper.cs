using AutoMapper;
using APPLICATION.Dto.TemplateGradeBookItemDetail;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class TemplateGradeBookItemDetailMapper : Profile
{
    public TemplateGradeBookItemDetailMapper()
    {
        CreateMap<TemplateGradeBookItemDetailDto, TemplateGradeBookItemDetail>();
        CreateMap<TemplateGradeBookItemDetail, GetTemplateGradeBookItemDetailDto>();
    }
}
