using APPLICATION.Dto.SkillsFrameworkJobRole;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkJobRoleService:GenericService<SkillsFrameworkJobRole, GetSkillsFrameworkJobRoleDto>, ISkillsFrameworkJobRoleService
{
    public SkillsFrameworkJobRoleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
