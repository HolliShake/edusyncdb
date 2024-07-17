using AutoMapper;
using APPLICATION.Dto.ScholarshipList;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ScholarshipListMapper : Profile
{
    public ScholarshipListMapper()
    {
        CreateMap<ScholarshipListDto, ScholarshipList>();
        CreateMap<ScholarshipList, GetScholarshipListDto>();
    }
}
