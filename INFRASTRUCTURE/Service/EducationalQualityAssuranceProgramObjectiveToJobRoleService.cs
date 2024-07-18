using APPLICATION.Dto.EducationalQualityAssuranceProgramObjectiveToJobRole;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceProgramObjectiveToJobRoleService:GenericService<EducationalQualityAssuranceProgramObjectiveToJobRole, GetEducationalQualityAssuranceProgramObjectiveToJobRoleDto>, IEducationalQualityAssuranceProgramObjectiveToJobRoleService
{
    public EducationalQualityAssuranceProgramObjectiveToJobRoleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
