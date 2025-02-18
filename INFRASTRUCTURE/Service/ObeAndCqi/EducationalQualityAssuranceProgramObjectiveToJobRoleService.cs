using AutoMapper;
using APPLICATION.Dto.EducationalQualityAssuranceProgramObjectiveToJobRole;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class EducationalQualityAssuranceProgramObjectiveToJobRoleService:GenericService<EducationalQualityAssuranceProgramObjectiveToJobRole, GetEducationalQualityAssuranceProgramObjectiveToJobRoleDto>, IEducationalQualityAssuranceProgramObjectiveToJobRoleService
{
    public EducationalQualityAssuranceProgramObjectiveToJobRoleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
