using AutoMapper;
using APPLICATION.Dto.ScholarshipApplication;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ScholarshipApplicationMapper : Profile
{
    public ScholarshipApplicationMapper()
    {
        CreateMap<ScholarshipApplicationDto, ScholarshipApplication>();
        CreateMap<ScholarshipApplication, GetScholarshipApplicationDto>();
    }
}
