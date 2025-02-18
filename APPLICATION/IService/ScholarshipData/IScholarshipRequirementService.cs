using APPLICATION.Dto.ScholarshipRequirement;
using DOMAIN.Model;

namespace APPLICATION.IService.ScholarshipData;

public interface IScholarshipRequirementService:IGenericService<ScholarshipRequirement, GetScholarshipRequirementDto>
{
}
