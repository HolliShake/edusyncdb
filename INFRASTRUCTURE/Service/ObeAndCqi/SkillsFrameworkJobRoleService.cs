using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkJobRole;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkJobRoleService:GenericService<SkillsFrameworkJobRole, GetSkillsFrameworkJobRoleDto>, ISkillsFrameworkJobRoleService
{
    public SkillsFrameworkJobRoleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
