using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkProficiencyLevel;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkProficiencyLevelService:GenericService<SkillsFrameworkProficiencyLevel, GetSkillsFrameworkProficiencyLevelDto>, ISkillsFrameworkProficiencyLevelService
{
    public SkillsFrameworkProficiencyLevelService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
