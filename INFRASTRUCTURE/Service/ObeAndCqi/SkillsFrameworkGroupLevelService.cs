using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkGroupLevel;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkGroupLevelService:GenericService<SkillsFrameworkGroupLevel, GetSkillsFrameworkGroupLevelDto>, ISkillsFrameworkGroupLevelService
{
    public SkillsFrameworkGroupLevelService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
