using APPLICATION.Dto.SkillsFrameworkPerformaceExpectationToJobRole;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkPerformaceExpectationToJobRoleService:GenericService<SkillsFrameworkPerformaceExpectationToJobRole, GetSkillsFrameworkPerformaceExpectationToJobRoleDto>, ISkillsFrameworkPerformaceExpectationToJobRoleService
{
    public SkillsFrameworkPerformaceExpectationToJobRoleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
