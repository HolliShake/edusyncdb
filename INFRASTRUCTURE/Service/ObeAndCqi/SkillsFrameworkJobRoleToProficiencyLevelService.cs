using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkJobRoleToProficiencyLevel;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkJobRoleToProficiencyLevelService:GenericService<SkillsFrameworkJobRoleToProficiencyLevel, GetSkillsFrameworkJobRoleToProficiencyLevelDto>, ISkillsFrameworkJobRoleToProficiencyLevelService
{
    public SkillsFrameworkJobRoleToProficiencyLevelService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
