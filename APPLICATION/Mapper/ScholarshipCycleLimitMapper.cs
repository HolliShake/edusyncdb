using AutoMapper;
using APPLICATION.Dto.ScholarshipCycleLimit;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ScholarshipCycleLimitMapper : Profile
{
    public ScholarshipCycleLimitMapper()
    {
        CreateMap<ScholarshipCycleLimitDto, ScholarshipCycleLimit>();
        CreateMap<ScholarshipCycleLimit, GetScholarshipCycleLimitDto>();
    }
}
