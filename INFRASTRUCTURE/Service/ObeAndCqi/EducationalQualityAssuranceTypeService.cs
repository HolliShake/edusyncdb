using AutoMapper;
using APPLICATION.Dto.EducationalQualityAssuranceType;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class EducationalQualityAssuranceTypeService:GenericService<EducationalQualityAssuranceType, GetEducationalQualityAssuranceTypeDto>, IEducationalQualityAssuranceTypeService
{
    public EducationalQualityAssuranceTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
