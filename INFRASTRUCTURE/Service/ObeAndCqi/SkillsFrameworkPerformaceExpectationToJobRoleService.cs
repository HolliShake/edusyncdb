using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkPerformaceExpectationToJobRole;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkPerformaceExpectationToJobRoleService:GenericService<SkillsFrameworkPerformaceExpectationToJobRole, GetSkillsFrameworkPerformaceExpectationToJobRoleDto>, ISkillsFrameworkPerformaceExpectationToJobRoleService
{
    public SkillsFrameworkPerformaceExpectationToJobRoleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
