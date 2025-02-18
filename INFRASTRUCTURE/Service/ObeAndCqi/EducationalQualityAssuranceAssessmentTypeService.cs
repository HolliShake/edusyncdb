using AutoMapper;
using APPLICATION.Dto.EducationalQualityAssuranceAssessmentType;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class EducationalQualityAssuranceAssessmentTypeService:GenericService<EducationalQualityAssuranceAssessmentType, GetEducationalQualityAssuranceAssessmentTypeDto>, IEducationalQualityAssuranceAssessmentTypeService
{
    public EducationalQualityAssuranceAssessmentTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
