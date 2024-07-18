using APPLICATION.Dto.EducationalQualityAssuranceAssessmentType;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceAssessmentTypeService:GenericService<EducationalQualityAssuranceAssessmentType, GetEducationalQualityAssuranceAssessmentTypeDto>, IEducationalQualityAssuranceAssessmentTypeService
{
    public EducationalQualityAssuranceAssessmentTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
