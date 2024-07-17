using AutoMapper;
using APPLICATION.Dto.Curriculum;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CurriculumMapper : Profile
{
    public CurriculumMapper()
    {
        CreateMap<CurriculumDto, Curriculum>();
        CreateMap<Curriculum, GetCurriculumDto>();
    }
}
