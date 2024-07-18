using APPLICATION.Dto.EducationalQualityAssuranceType;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceTypeService:GenericService<EducationalQualityAssuranceType, GetEducationalQualityAssuranceTypeDto>, IEducationalQualityAssuranceTypeService
{
    public EducationalQualityAssuranceTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
