using AutoMapper;
using APPLICATION.Dto.CurriculumDetail;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CurriculumDetailMapper : Profile
{
    public CurriculumDetailMapper()
    {
        CreateMap<CurriculumDetailDto, CurriculumDetail>();
        CreateMap<CurriculumDetail, GetCurriculumDetailDto>();
    }
}
