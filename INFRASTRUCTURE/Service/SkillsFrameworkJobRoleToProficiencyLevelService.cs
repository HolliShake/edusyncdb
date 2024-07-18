using APPLICATION.Dto.SkillsFrameworkJobRoleToProficiencyLevel;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkJobRoleToProficiencyLevelService:GenericService<SkillsFrameworkJobRoleToProficiencyLevel, GetSkillsFrameworkJobRoleToProficiencyLevelDto>, ISkillsFrameworkJobRoleToProficiencyLevelService
{
    public SkillsFrameworkJobRoleToProficiencyLevelService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
